using DesktopComsumer.Models;
using DesktopConsumer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TokenState currentState = TokenState.Invalid;
            string tokenValue = await GetToken(currentState);
            return await tournamentService.GetAllTournaments(tokenValue);
        }
        public async Task<Tournament> GetTournamentById(int id)
        {
            return await tournamentService.GetTournamentById(id);
        }

        public async Task<int> CreateTournament(Tournament tournament)
        {
            return await tournamentService.CreateTournament(tournament);
        }

        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;
        }
    }
}
