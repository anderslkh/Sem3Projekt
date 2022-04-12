using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {

	public class PersonsController : Controller {
		// GET: api/persons
		[Route("api/[controller]")]
		public IActionResult Index() {
			IManager<Person, string> personManager = new PersonManager();
			if (personManager.GetAll() != null)
			{
				return Ok(personManager.GetAll().ToJson());
			}

			return NotFound();
		}

		// GET: api/persons/5
		[Route("api/[controller]/{email}")]
		public IActionResult Details(string? email) {
			IManager<Person, string> personManager = new PersonManager();
			if (personManager.GetById(email) != null)
			{
				return Ok(personManager.GetById(email));
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
