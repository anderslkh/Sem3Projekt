using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Managers;
using WebAPI.ModelDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollInTournament([FromBody]EnrollmentDTO enrollmentDTO)
        {
            ITournamentManager<EnrollmentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
            int result = tournamentManager.EnrollInTournament(enrollmentDTO);
            if (result == 1)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
