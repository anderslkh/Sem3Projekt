using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using WebAPI.Data;
using WebAPI.Managers;
using WebAPI.Model_DTO_s;
using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.Controllers {
	[Authorize]
    public class TournamentsController : Controller {
		// GET: TournamentsController
        [Route("api/[controller]")]
		public IActionResult Index()
		{
			IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			List<TournamentDTO> foundTournaments = tournamentManager.GetAllItems();
			if (foundTournaments.Any())
			{
				return Ok(foundTournaments.ToJson());
			}

			return NotFound();
		}

		// GET: api/tournaments/5
		[Route("api/[controller]/{TournamentId}")]
		public IActionResult Details(int tournamentId)
		{
			IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			TournamentDTO foundTournament = tournamentManager.GetItemById(tournamentId);
			if (foundTournament != null)
			{
				return Ok(foundTournament.ToJson());
			}

			return Unauthorized();
		}

        [Route("api/[controller]/enroll/{TournamentId}")]
		[HttpPost]
        public ActionResult Enroll([FromBody]EnrollmentDTO enrollmentDto)
        {
	        IManager<TournamentDTO, int> manager = ManagerFactory.CreateTournamentManager();
            if (manager is TournamentManager tournamentManager)
            {
                return Ok(tournamentManager.EnrollInTournament(enrollmentDto));
            }
            return Unauthorized();
			// another error code
        }

		// GET: TournamentsController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: TournamentsController/Create
        [Route("api/[controller]/Create")]
		[HttpPost]
        public ActionResult Create([FromBody]TournamentDTO inTournament)
        {
            if (inTournament != null)
            {
                //TournamentDTO tournamentToCreate = new TournamentDTO(tournament.TournamentName, tournament.TimeOfEvent,
                //    tournament.RegistrationDeadline, tournament.MaxParticipants, tournament.MinParticipants);
                IManager<TournamentDTO, int> manager = ManagerFactory.CreateTournamentManager();
                manager.CreateItem(inTournament);
                return Ok(new Response{Status = "Success", Message = "Tournament successfully created"});
            }

            return BadRequest(new Response{Status = "Error", Message = "Tournament not created"});
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

		//// GET: TournamentsController/Delete/5
		//public ActionResult Delete(int id) {
		//	return View();
		//}

		// POST: TournamentsController/Delete/5
		
		
		[Route("api/[controller]/delete/{TournamentId}")]
		[HttpDelete]
		public ActionResult Delete(int tournamentId) {
			IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
			//TournamentDTO foundTournament = tournamentManager.GetItemById(tournamentId);
			//if (foundTournament != null)
			//{
			//	tournamentManager.DeleteItem(tournamentId);
			//}
			//tournamentManager.DeleteItem(tournamentId);
			if (tournamentManager.DeleteItem(tournamentId))
			{
				return Ok();
			}

			return NotFound();
			//if (tournamentManager.DeleteItem(tournamentId))
			//         {
			//	return Ok();
			//         }
			//return NotFound();
		}
	}
}
