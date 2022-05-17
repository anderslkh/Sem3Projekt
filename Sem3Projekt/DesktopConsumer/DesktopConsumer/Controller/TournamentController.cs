using DesktopConsumer.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopConsumer.Models;

namespace DesktopConsumer.Controller
{
    public class TournamentController
    {
        private TournamentService tournamentService;

        public TournamentController()
        {
            tournamentService = new TournamentService();
        }

        public async Task<List<Tournament>> GetAllTournaments()
        {
            return await tournamentService.GetAllTournaments();
        }
        public async Task<Tournament> GetTournamentById(int id)
        {
            return await tournamentService.GetTournamentById(id);
        }

        public async Task<int> CreateTournament(Tournament tournament)
        {
            return await tournamentService.CreateTournament(tournament);
        }
    }
}
