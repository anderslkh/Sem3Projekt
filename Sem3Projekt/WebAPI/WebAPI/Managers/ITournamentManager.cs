using WebAPI.Models;

namespace WebAPI.Managers
{
    public interface ITournamentManager : IManager<Tournament, int>
    {
        bool EnrollInTournament(string email, int id);
    }
}
