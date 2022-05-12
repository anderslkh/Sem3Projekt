using Microsoft.AspNetCore.Mvc;
using WebAPI.Managers;
using WebAPI.Model_DTO_s;
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

        [HttpPut("{TournamentId}")]
        public ActionResult EnrollInTournament([FromBody] EnrollmentDTO enrollmentDTO)
        {
            IManager<TournamentDTO, int> manager = ManagerFactory.CreateTournamentManager();
            if (manager is TournamentManager tournamentManager)
            {
                return Ok(tournamentManager.EnrollInTournament(enrollmentDTO));
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
