using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers {
	public class TournamentManager : IManager<Tournament, int> {
		public Tournament GetItemById(int tournamentId) {
			Tournament foundTournament = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try {
				foundTournament = tournamentDao.GetItemById(tournamentId);
			} catch (Exception e) {
				throw;
			}

			return foundTournament;
		}

		public bool EnrollInTournament(string personEmail, int tournamentId) {
			bool result = false;
			IDao<Tournament, int> dao = DaoFactory.CreateTournamentDao();
			int maxParticipants = 0;

			try {
				//if (dao is TournamentDao tournamentDao)
				//{
				//	ParticipantsInTournament foundParticipantsInTournament = tournamentDao.GetTournamentParticipantsAndMax(tournamentId);

				//	if (foundParticipantsInTournament.MaxParticipants > foundParticipantsInTournament.ParticipantEmails.Count && !foundParticipantsInTournament.ParticipantEmails.Contains(personEmail))
				//	{
				//		tournamentDao.EnrollInTournament(personEmail, tournamentId);
				//	}
				//}

				if (dao is TournamentDao tournamentDao) {
					maxParticipants = tournamentDao.CheckTournamentMaxAvailability(tournamentId);
					tournamentDao = (TournamentDao)DaoFactory.CreateTournamentDao();
					if (maxParticipants > tournamentDao.GetNoOfParticipants(tournamentId))
					{
						tournamentDao = (TournamentDao) DaoFactory.CreateTournamentDao();
						if (!tournamentDao.IsParticipant(personEmail, tournamentId)) {
							tournamentDao = (TournamentDao)DaoFactory.CreateTournamentDao();
							result = tournamentDao.EnrollInTournament(personEmail, tournamentId);
						}
					}
					

				}





			} catch (Exception e) {
				throw;
			}

			return result;
		}


		public List<Tournament> GetAllItems() {
			List<Tournament> foundTournaments = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try {
				foundTournaments = tournamentDao.GetAllItems();
			} catch (Exception e) {
				throw;
			}

			return foundTournaments;
		}

        public bool CreateItem(Tournament item)
        {
            throw new NotImplementedException();
        }
    }
}
