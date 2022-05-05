using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebComsumer.Models;
using WebConsumer.Models;
using WebConsumer.Service;

namespace WebConsumer.Controllers {
	[Authorize]
	public class TournamentsController : Controller {
		// GET: TournamentsController
		public async Task<IActionResult> Index() {
			TournamentService tournamentService = new TournamentService((User as ClaimsPrincipal).FindFirst("access_token").Value);
			return View(await tournamentService.GetAllItems());
		}
		// GET: TournamentsController/Details/5
		[Route("[controller]/{TournamentId}")]
		public async Task<IActionResult> Details(int tournamentId) {
			TournamentService tournamentService = new TournamentService((User as ClaimsPrincipal).FindFirst("access_token").Value);

			return View(await tournamentService.GetItem(tournamentId));
		}

		//public ActionResult Enroll()
		//{
		//    PersonService personService = new PersonService();
		//    Person foundPerson = personService.GetPersonByEmail("test@test");

		//    return View();
		//}

		[HttpGet]
		[Route("[controller]/enroll/{TournamentId}")]
		public ActionResult Enroll(int tournamentId, int enrolledParticipants) {
			return View(new EnrollmentDTO(tournamentId, enrolledParticipants, User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")));
		}

		[HttpPost]
		[Route("[controller]/enroll/{TournamentId}")]
		public async Task<ActionResult> Enroll(int tournamentId, int enrolledParticipants, string personEmail) {
			int result = -1;
			EnrollmentDTO enrollmentDto = new EnrollmentDTO(tournamentId, enrolledParticipants, personEmail);
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
					return View("ErroResult");
					break;
				}
			}

			return View("SuccesResult");
		}

		

		// GET: TournamentsController/Create
		public ActionResult Create() {
			return View();
		}

		public ActionResult NoRoomResult() {
			return View();
		}

		public ActionResult ErroResult()
		{
			return View();
		}

		public ActionResult SuccesResult()
		{
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
