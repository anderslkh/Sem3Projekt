using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers {
	public class TournamentManager : IManager<Tournament, int> {
		public Tournament GetItemById(int tournamentId)
		{
			Tournament foundTournament = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try
			{
				foundTournament = tournamentDao.GetItemById(tournamentId);
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
                if (dao is TournamentDao tournamentDao && tournamentDao.CheckTournamentMaxAvailability(tournamentId))
                {
                    result = tournamentDao.EnrollInTournament(personEmail, tournamentId);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

		public List<Tournament> GetAllItems()
		{
			List<Tournament> foundTournaments = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try
			{
				foundTournaments = tournamentDao.GetAllItems();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return foundTournaments;
		}
	}
}
