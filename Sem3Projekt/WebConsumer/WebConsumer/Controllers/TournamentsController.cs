using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumer.Models;
using WebConsumer.Service;

namespace WebConsumer.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: TournamentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TournamentsController/Details/5
        [Route ("[controller]/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            TournamentService tournamentService = new TournamentService();
           
            return View( await tournamentService.GetTournamentById(id));
        }

        //public ActionResult Enroll()
        //{
        //    PersonService personService = new PersonService();
        //    Person foundPerson = personService.GetPersonByEmail("test@test");

        //    return View();
        //}

        [HttpGet]
        [Route("[controller]/enroll/{id}")]
        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/enroll/{id}")]
        public async Task<ActionResult> Enroll(int id, string email)
        {
            PersonService personService = new PersonService();
            Person newP = await personService.GetPersonByEmail(email);
            TournamentService tournamentService = new TournamentService();
            return View(await tournamentService.EnrollInTournament(id, newP));
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
