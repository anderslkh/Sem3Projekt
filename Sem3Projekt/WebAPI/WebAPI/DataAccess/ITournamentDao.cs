using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public interface ITournamentDao<T> : IDao<Tournament, int>
    {
        int EnrollInTournament(T item);


    }
}
