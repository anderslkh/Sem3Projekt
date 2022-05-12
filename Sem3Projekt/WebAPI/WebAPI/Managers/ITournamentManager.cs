using WebAPI.ModelDTOs;

namespace WebAPI.Managers
{
    public interface ITournamentManager<T, I> : IManager<TournamentDTO, I>
    {
        I EnrollInTournament(T enrollmentDto);
    }
}
