using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumer.Models;
using WebConsumer.Service;

namespace WebConsumer.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        // GET: PersonsController
        [HttpGet]
        
        public async Task<IActionResult> Index()
        {
	        IService<Person, string> personService = ServiceFactory.CreatePersonService();
            return View(await personService.GetAllItems());
        }

        // GET: PersonsController/Details/5
        [Route("{email}")]
        [HttpGet]
        public async Task<IActionResult> Details(string email)
        {
            IService<Person, string> personService = ServiceFactory.CreatePersonService();
            Person foundPerson = await personService.GetItem(email);
            return View(foundPerson);
        }

		//GET: PersonsController/Create

		[Route("create")]
		[HttpGet]
		public ActionResult Create() {
			return View();
		}

		// POST: PersonsController/Create
		[Route("create")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: PersonsController/Edit/5
		[Route("Edit/{id}")]
		[HttpGet]
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: PersonsController/Edit/5
		[Route("edit/{id}")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection) {
			try {
				return RedirectToAction(nameof(Index));
			} catch {
				return View();
			}
		}

		// GET: PersonsController/Delete/5
		[Route("delete/{id}")]
		[HttpGet]
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: PersonsController/Delete/5
		[Route("delete/{id}")]
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
