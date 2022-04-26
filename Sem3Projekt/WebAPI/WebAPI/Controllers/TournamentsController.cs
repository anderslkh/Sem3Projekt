using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {
	public class TournamentsController : Controller {
		// GET: TournamentsController
		[Route("api/[controller]")]
		public IActionResult Index()
		{
			IManager<Tournament, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			List<Tournament> foundTournaments = tournamentManager.GetAllItems();
			if (foundTournaments.Any())
			{
				return Ok(foundTournaments.ToJson());
			}

			return NotFound();
		}

		// GET: api/tournaments/5
		[Route("api/[controller]/{tournamentId}")]
		public IActionResult Details(int tournamentId)
		{
			IManager<Tournament, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			Tournament foundTournament = tournamentManager.GetItemById(tournamentId);
			if (foundTournament != null)
			{
				return Ok(foundTournament.ToJson());
			}

			return NotFound();
		}

        [Route("api/[controller]/enroll/{tournamentId}")]
		[HttpPost]
        public ActionResult Enroll([FromBody]Person inPerson, int tournamentId)
        {
            IManager<Tournament, int> manager = ManagerFactory.CreateTournamentManager();
            if (manager is TournamentManager tournamentManager)
            {
                return Ok(tournamentManager.EnrollInTournament(inPerson.email, tournamentId));
            }
            return NotFound();
			// another error code
        }

		// GET: TournamentsController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: TournamentsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: TournamentsController/Edit/5
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: TournamentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: TournamentsController/Delete/5
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: TournamentsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}
	}
}
