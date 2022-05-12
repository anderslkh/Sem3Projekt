using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using WebAPI.Data;
using WebAPI.Managers;
using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.Controllers {
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase {
        // GET: api/<Tournaments>
        [HttpGet]
        public ActionResult<List<TournamentDTO>> GetAllTournaments()
        {
            IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
            List<TournamentDTO> foundTournaments = tournamentManager.GetAllItems();
            if (foundTournaments.Any())
            {
                return Ok(foundTournaments.ToJson());
            }
            return NotFound();
        }

        // GET api/<Tournaments>/5
        [HttpGet]
        [Route("{TournamentId}")]
        public ActionResult<TournamentDTO> GetTournamentById(int tournamentId)
        {
            IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
            TournamentDTO foundTournament = tournamentManager.GetItemById(tournamentId);
            if (foundTournament != null)
            {
                return Ok(foundTournament.ToJson());
            }
            return NotFound();
        }

        // POST api/<Tournaments>
        [HttpPost]
        public ActionResult CreateTournament([FromBody] TournamentDTO inTournament)
        {
            if (inTournament != null)
            {
                //TournamentDTO tournamentToCreate = new TournamentDTO(tournament.TournamentName, tournament.TimeOfEvent,
                //    tournament.RegistrationDeadline, tournament.MaxParticipants, tournament.MinParticipants);
                IManager<TournamentDTO, int> manager = ManagerFactory.CreateTournamentManager();
                manager.CreateItem(inTournament);
                return Ok(new Response { Status = "Success", Message = "Tournament successfully created" });
            }

            return BadRequest(new Response { Status = "Error", Message = "Tournament not created" });
        }

        // PUT api/<Tournaments>/5
        [HttpPut("{TournamentId}")]
        public ActionResult UpdateTournament([FromBody] EnrollmentDTO enrollmentDTO)
        {
            //implement update method for tournament
            return null;
        }

        // DELETE api/<Tournaments>/5
        [HttpDelete("{TournamentId}")]
        public ActionResult DeleteTournament(int tournamentId)
        {
            IManager<TournamentDTO, int> tournamentManager = ManagerFactory.CreateTournamentManager();
            if (tournamentManager.DeleteItem(tournamentId))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
