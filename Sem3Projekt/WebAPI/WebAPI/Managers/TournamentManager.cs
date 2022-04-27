using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers
{
    public class TournamentManager : ITournamentManager
    {
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
                if (dao is TournamentDao tournamentDao)
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

        public bool CreateItem(Tournament tournament)
        {
            bool res = false;
            TournamentDao tournamentDao = (TournamentDao)DaoFactory.CreateTournamentDao();
            try
            {
                res = tournamentDao.CreateItem(tournament);
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }

        public bool UpdateItem(Tournament tournament)
        {
            bool res = false;
            TournamentDao tournamentDao = (TournamentDao)DaoFactory.CreateTournamentDao();
            try
            {
                res = tournamentDao.UpdateItem(tournament);
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }

        public bool DeleteItem(int tournamentId)
        {
            bool res = false;
            TournamentDao tournamentDao = (TournamentDao)DaoFactory.CreateTournamentDao();
            try
            {
                res = tournamentDao.DeleteItem(tournamentId);
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}
