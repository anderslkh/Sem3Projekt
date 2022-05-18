using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase {
        // GET: api/persons
        [HttpGet]
        public ActionResult<List<Person>> GetAllPersons()
        {
            IManager<Person, string> personManager = ManagerFactory.CreatePersonManager();
            List<Person> foundList = personManager.GetAllItems();
            if (foundList.Any())
            {
                return Ok(foundList.ToJson());
            }

            return NotFound();
        }

        // GET api/persons/mail@mail.com
        [HttpGet]
        [Route("{PersonEmail}")]
        public ActionResult<Person> GetTournamentById(string personEmail)
        {
            IManager<Person, string> personManager = ManagerFactory.CreatePersonManager();
            Person foundPerson = personManager.GetItemById(personEmail);
            if (foundPerson != null)
            {
                return Ok(foundPerson.ToJson());
            }
            return NotFound();
        }
    }
}
