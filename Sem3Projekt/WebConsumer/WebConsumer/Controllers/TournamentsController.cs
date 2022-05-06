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

        [HttpGet]
		[Route("[controller]/enroll/{TournamentId}")]
		public ActionResult Enroll(int tournamentId, int enrolledParticipants, int maxNoOfParticipants)
		{
			EnrollmentDTO enrollmentDto = new EnrollmentDTO(tournamentId, enrolledParticipants, User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"), maxNoOfParticipants);
			return View(enrollmentDto);
		}

		[HttpPost]
		[Route("[controller]/enroll/{TournamentId}")]
		public async Task<ActionResult> Enroll(int tournamentId, int enrolledParticipants, string personEmail, int maxNoOfParticipants) {
			int result = -1;
			EnrollmentDTO enrollmentDto = new EnrollmentDTO(tournamentId, enrolledParticipants, personEmail, maxNoOfParticipants);
			TournamentService tournamentService = new TournamentService(User.FindFirst("access_token").Value);
			try
			{
				result = await tournamentService.EnrollInTournament(enrollmentDto);
			}
			catch
			{
			}

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
			}

			return View("SuccesResult");
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
