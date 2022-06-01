using System.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using NuGet.Packaging.Rules;
using WebAPI.DataAccess;
using WebAPI.ModelDTOs;
using WebAPI.Models;

namespace WebAPI.Managers {
	public class TournamentManager : ITournamentManager<EnrollmentDTO, int> {

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
                    foundTournament.EnrolledParticipants);
            }
            catch (Exception e)
            {
//    public class TournamentManager : IManager<TournamentDTO, int>
//    {
//        public TournamentDTO GetItemById(int tournamentId)
//        {
//            Tournament foundTournament = null;
//            TournamentDTO tournamentToTransfer = null;
//            ITournamentDao<EnrollmentDTO> tournamentDao = DaoFactory.CreateTournamentDao();
//            try
//            {
//                foundTournament = tournamentDao.GetItemById(tournamentId);
//                tournamentToTransfer = new TournamentDTO(foundTournament.TournamentId,
//                    foundTournament.TournamentName,
//                    foundTournament.TimeOfEvent,
//                    foundTournament.RegistrationDeadline,
//                    foundTournament.MaxParticipants,
//                    foundTournament.MinParticipants,
//                    foundTournament.ListOfParticipantIds.Count);
//            }
//            catch (Exception e)
                {
                    throw;
                }
            }
            return tournamentToTransfer;
        }

        public int EnrollInTournament(EnrollmentDTO enrollmentDto)
        {
            int result = -1;
            // Creating a data access object to communicate with datasource.
            ITournamentDao<EnrollmentDTO> tournamentDao = DaoFactory.CreateTournamentDao();
            try
            {
                // If the created instance of the IDao is a tournamentDao then it's cast to be so,
                // which gives access to the methods within tournamentDao spicifically.
                // This is because the method Enroll is not general, it is only relevant for tournaments.
                // The the if statement also checks if there is room in the tournament, before accessing datasource.
                if (enrollmentDto.MaxParticipants > enrollmentDto.EnrolledParticipants)
                {
                    result = tournamentDao.EnrollInTournament(enrollmentDto);
                }
            }
            catch (Exception e)
            {
	            result = -1;
            }
            return result;
        }


        public List<TournamentDTO> GetAllItems()
        {
            List<Tournament> foundTournaments = null;
            List<TournamentDTO> tournamentsToTransfer = new List<TournamentDTO>();
            ITournamentDao<EnrollmentDTO> tournamentDao = DaoFactory.CreateTournamentDao();
            try
            {
                foundTournaments = tournamentDao.GetAllItems();
                foreach (Tournament tournament in foundTournaments)
                {
                    tournamentsToTransfer.Add(new TournamentDTO(tournament.TournamentId,
                        tournament.TournamentName,
                        tournament.TimeOfEvent,
                        tournament.RegistrationDeadline,
                        tournament.MaxParticipants,
                        tournament.MinParticipants,
                        tournament.EnrolledParticipants));
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return tournamentsToTransfer;
        }

        public bool CreateItem(TournamentDTO tournamentDTO) {
            bool result = false;
            Tournament tournament = new Tournament(tournamentDTO.TournamentId,
                    tournamentDTO.TournamentName,
                    tournamentDTO.TimeOfEvent,
                    tournamentDTO.RegistrationDeadline,
                    tournamentDTO.MinParticipants,
                    tournamentDTO.MaxParticipants
                    );

            ITournamentDao<EnrollmentDTO> tournamentDao = DaoFactory.CreateTournamentDao();
            try {
                if (tournamentDao.CreateItem(tournament) > 0) {
                    result = true;
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

        public bool DeleteItem(int tournamentId)
        {
            bool res = false;
            ITournamentDao<EnrollmentDTO> tournamentDao = DaoFactory.CreateTournamentDao();
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

        public bool UpdateItem(TournamentDTO item)
        {
            throw new NotImplementedException();
        }

        
    }
}
