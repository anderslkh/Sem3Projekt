using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumer.Models;
using WebConsumer.Service;

namespace WebConsumer.Controllers {
	[Authorize]
	public class TournamentsController : Controller {
		// GET: TournamentsController
		public async Task<IActionResult> Index() {
			TournamentService tournamentService = new TournamentService(User.FindFirstValue("access_token"));
			return View(await tournamentService.GetAllItems());
		}
		// GET: TournamentsController/Details/5
		[Route("[controller]/{TournamentId}")]
		public async Task<IActionResult> Details(int tournamentId) {
			TournamentService tournamentService = new TournamentService(User.FindFirstValue("access_token"));

			return View(await tournamentService.GetItem(tournamentId));
		}
		
		// Get request of enroll with tournament id,
		// how many already enrolled,
		// and the maximum amount that can enroll to spicific tournament.
		// Information is provided from previous View. (Get request of Index in tournamentcontroller, the list of tournaments)
		//
		// Get: Tournamentcontroller/enroll/5
        [HttpGet]
		[Route("[controller]/enroll/{TournamentId}")]
		public ActionResult Enroll(int tournamentId, int enrolledParticipants, int maxNoOfParticipants)
		{
			EnrollmentDTO enrollmentDto = new EnrollmentDTO(tournamentId, enrolledParticipants, User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"), maxNoOfParticipants);
			return View(enrollmentDto);
		}

		// Post request of enroll, with tournament id,
		// how many already enrolled,
		// the email (id) of the person trying to enroll,
		// and the maximum amount that can enroll to spicific tournament.
		// This information is provided from the previous view. (Get request of enroll)
		//
		// Post: Tournamentcontroller/enroll/5
		[HttpPost]
		[Route("[controller]/enroll/{TournamentId}")]
		public async Task<ActionResult> Enroll(int tournamentId, int enrolledParticipants, string personEmail, int maxNoOfParticipants) {
			int result = -1;
			// Create a Enrollment object which has the needed information to try and enroll a user into a tournament.
			EnrollmentDTO enrollmentDto = new EnrollmentDTO(tournamentId, enrolledParticipants, personEmail, maxNoOfParticipants);
			TournamentService tournamentService = new TournamentService(User.FindFirst("access_token").Value);
			
			result = await tournamentService.EnrollInTournament(enrollmentDto);
			
			// SwitchCase from enrollment attempt.
			// (1) If the attempt results in a 1, the user is now enrolled in the tournament.
			// (0) If the attempt results in a 0, the user is already enrolled in the tournament.
			// (-1) If the attempt results in a -1, the user cannot enrolled since the tournament is allready full.
			// One of three view are returned, depending on the result.
			switch (result)
			{
				case -1:
				{
					return View("NoRoomResult");
					break;
				}
				case 0:
				{
					return View("AlreadyEnrolled");
					break;
				}
				default:
				{
					return View("SuccesResult");
					break;
				}
			}

			
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
