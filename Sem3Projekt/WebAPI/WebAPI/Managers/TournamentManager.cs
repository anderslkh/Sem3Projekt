using Microsoft.Data.SqlClient;
using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.Model_DTO_s;
using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.Managers {
	public class TournamentManager : IManager<TournamentDTO, int> {
		public TournamentDTO GetItemById(int tournamentId) {
			Tournament foundTournament = null;
			TournamentDTO tournamentToTransfer = null;
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try
			{
				foundTournament = tournamentDao.GetItemById(tournamentId);
				tournamentToTransfer = new TournamentDTO(foundTournament.TournamentId,
					foundTournament.TournamentName,
					foundTournament.TimeOfEvent,
					foundTournament.RegistrationDeadline,
					foundTournament.MaxParticipants,
					foundTournament.MinParticipants,
					foundTournament.ListOfParticipantIds.Count);
			}
			catch (Exception e)
            {
                throw;
            }

			return tournamentToTransfer;
		}

		public int EnrollInTournament(EnrollmentDTO enrollmentDto) {
			int result = -1;
			// Creating a data access object to communicate with datasource.
			IDao<Tournament, int> dao = DaoFactory.CreateTournamentDao();
			try
			{
				// If the created instance of the IDao is a tournamentDao then it's cast to be so,
				// which gives access to the methods within tournamentDao spicifically.
				// This is because the method Enroll is not general, it is only relevant for tournaments.
				// The the if statement also checks if there is room in the tournament, before accessing datasource.
				if (dao is TournamentDao tournamentDao && enrollmentDto.MaxNoOfParticipants > enrollmentDto.EnrolledParticipants)
				{
					result = tournamentDao.EnrollInTournament(enrollmentDto);
				}
			}
			catch (Exception e)
			{
				// If an exception is thrown by the datasource,
				// it is because the user trying to enroll, already is enrolled.
				result = 0;
			}
			return result;
		}


		public List<TournamentDTO> GetAllItems() {
			List<Tournament> foundTournaments = null;
			List<TournamentDTO> tournamentsToTransfer = new List<TournamentDTO>();
			IDao<Tournament, int> tournamentDao = DaoFactory.CreateTournamentDao();
			try {
				foundTournaments = tournamentDao.GetAllItems();
				foreach (Tournament tournament in foundTournaments) {
					tournamentsToTransfer.Add(new TournamentDTO(tournament.TournamentId,
						tournament.TournamentName,
						tournament.TimeOfEvent,
						tournament.RegistrationDeadline,
						tournament.MaxParticipants,
						tournament.MinParticipants,
						tournament.ListOfParticipantIds.Count));
				}
			} catch (Exception e) {
				throw;
			}

			return tournamentsToTransfer;
		}

		public bool CreateItem(TournamentDTO item) {
			throw new NotImplementedException();
		}

	}
}
