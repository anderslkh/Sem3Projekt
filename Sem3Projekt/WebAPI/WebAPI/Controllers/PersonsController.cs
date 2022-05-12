using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebAPI.Managers;
using WebAPI.Models;

namespace WebAPI.Controllers {
	//[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase {
        // GET: api/<Persons>
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

        // GET api/<Persons>/mail@mail.com
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

        // POST api/<Persons>
        [HttpPost]
        public ActionResult CreatePerson([FromBody] Person inPerson)
        {
            return null;
        }

        // PUT api/<Persons>/mail@mail.com
        [HttpPut("{PersonEmail}")]
        public ActionResult UpdatePerson([FromBody] Person person)
        {
            return null;
        }

        // DELETE api/<Persons>/mail@mail.com
        [HttpDelete("{PersonEmail}")]
        public ActionResult DeletePerson(string personEmail)
        {
            return null;
        }
    }
}
