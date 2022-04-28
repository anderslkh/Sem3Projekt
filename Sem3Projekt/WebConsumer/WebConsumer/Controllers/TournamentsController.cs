using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebComsumer.Models;
using WebConsumer.Models;
using WebConsumer.Service;

namespace WebConsumer.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: TournamentsController
        public async Task<IActionResult> Index()
        {

	        IService<Tournament, int> tournamentService = ServiceFactory.CreateTournamentService();
	        return View(await tournamentService.GetAllItems());
        }

        // GET: TournamentsController/Details/5
        [Route ("[controller]/{tournamentId}")]
        public async Task<IActionResult> Details(int tournamentId)
        {
            TournamentService tournamentService = new TournamentService();
           
            return View( await tournamentService.GetItem(tournamentId));
        }

        //public ActionResult Enroll()
        //{
        //    PersonService personService = new PersonService();
        //    Person foundPerson = personService.GetPersonByEmail("test@test");

        //    return View();
        //}

        [HttpGet]
        [Route("[controller]/enroll/{tournamentId}")]
        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/enroll/{tournamentId}")]
        public async Task<ActionResult> Enroll(int tournamentId, string email)
        {

            try {
                PersonService personService = new PersonService();
                Person newP = await personService.GetItem(email);
                TournamentService tournamentService = new TournamentService();
                await tournamentService.EnrollInTournament(tournamentId, newP);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: TournamentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TournamentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TournamentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TournamentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TournamentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
