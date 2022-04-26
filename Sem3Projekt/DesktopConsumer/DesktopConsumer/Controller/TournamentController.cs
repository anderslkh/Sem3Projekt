using DesktopComsumer.Models;
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
            return await tournamentService.GetAllTournaments();
        }
        public async Task<Tournament> GetTournamentById(int id)
        {
            return await tournamentService.GetTournamentById(id);
        }
    }
}
