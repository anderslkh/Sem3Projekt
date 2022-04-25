using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers {
	public class TournamentManager : IManager<Tournament, int> {
		public Tournament GetById(int tournamentId)
		{
			Tournament foundTournament = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try
			{
				foundTournament = tournamentDao.GetById(tournamentId);
			}
			catch (Exception e)
			{
				throw;
			}

			return foundTournament;
		}
    
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

		public List<Tournament> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
