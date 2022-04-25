using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers {
    public class TournamentManager {

        public bool EnrollInTournament(string personEmail, int tournamentId)
        {
            bool result = false;
            IDao<Tournament, int> dao = DaoFactory.CreateTournamentDao();
            try
            {
                if (dao is TournamentDao tournamentDao)
                {
                    tournamentDao.EnrollInTournament(personEmail, tournamentId);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }
    }
}
