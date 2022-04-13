using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
	public class HomeController : Controller {
		// GET: HomeController
		[Route("[controller]")]
		public ActionResult Index() {
			return View();
		}

		// GET: HomeController/Details/5
		[Route("privacy")]
		public ActionResult Privacy() {
			return View();
		}
		
	}
}
