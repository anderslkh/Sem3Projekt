using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {
	[Route("api/[controller]")]
	public class PersonsController : Controller {
		// GET: api/persons
        [HttpGet]
		public IActionResult Index()
		{
            IManager<Person, string> personManager = ManagerFactory.CreatePersonManager();
			List<Person> foundList = personManager.GetAllItems();
			if (foundList.Any())
			{
				return Ok(foundList.ToJson());
			}

			return NotFound();
		}

		// GET: api/persons/5
        [Route("{email}")]
		public IActionResult Details(string email)
		{

			IManager<Person, string> personManager = ManagerFactory.CreatePersonManager();
			Person foundPerson = personManager.GetItemById(email);
			if (foundPerson != null)
			{
				return Ok(foundPerson.ToJson());
			}
			return NotFound();
		}

		// GET: PersonsController/Create
		public ActionResult Create() {
			return View();
		}

		// POST: PersonsController/Create
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
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: PersonsController/Edit/5
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
		public ActionResult Delete(int id) {
			return View();
		}

		// POST: PersonsController/Delete/5
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
