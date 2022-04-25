using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {
	public class TournamentsController : Controller {
		// GET: TournamentsController
		public ActionResult Index() {
			return View();
		}

		// GET: TournamentsController/Details/5
		[Route("api/[controller]/{tournamentId}")]
		public IActionResult Details(int tournamentId)
		{
			IManager<Tournament, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			Tournament foundTournament = tournamentManager.GetById(tournamentId);
			if (foundTournament != null)
			{
				return Ok(foundTournament.ToJson());
			}

			return NotFound();
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
