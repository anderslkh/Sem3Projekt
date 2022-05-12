using Microsoft.AspNetCore.Mvc;
using WebAPI.Managers;
using WebAPI.ModelDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        //// GET: api/<EnrollmentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<EnrollmentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EnrollmentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        public ActionResult EnrollInTournament([FromBody]EnrollmentDTO enrollmentDTO)
        {
            ITournamentManager<EnrollmentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
            if (tournamentManager.EnrollInTournament(enrollmentDTO) == 1)
            {
                return Ok();
            }
            return NotFound();
        }

        //// DELETE api/<EnrollmentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
