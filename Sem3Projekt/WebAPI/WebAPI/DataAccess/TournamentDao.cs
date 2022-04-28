using System.Data.SqlClient;
using Dapper;
using WebAPI.Models;

namespace WebAPI.DataAccess {
	public class TournamentDao : IDao<Tournament, int>
	{
		private readonly SqlConnection _conn;

		public TournamentDao(SqlConnection conn)
		{
			_conn = conn;
		}

		public Tournament GetItemById(int tournamentId)
		{
			Tournament foundTournament = null;
			string sqlQuery=
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new {TournamentId = tournamentId };
			
			using (_conn)
			{
				foundTournament = _conn.QuerySingle<Tournament>(sqlQuery, param);
			}
			return foundTournament;
		}
    
        public bool EnrollInTournament(string personEmail, int tournamentId)
        {
            bool result = false;
            string sqlQuery = "INSERT INTO PersonInTournament (PersonEmail, TournamentId) " +
            "VALUES (@PersonEmail, @TournamentId)";
            var param = new
            {
                PersonEmail = personEmail,
                TournamentId = tournamentId
            };
            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) > 0)
                {
                    result = true;
                }
            return result;
            }
        }

		public List<Tournament> GetAllItems()
		{
			List<Tournament> foundTournaments = null;
			string sqlQuery = "SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants FROM Tournament";
			using (_conn)
			{
				foundTournaments = _conn.Query<Tournament>(sqlQuery).ToList();
			}
			return foundTournaments;
		}

        public bool CreateItem(Tournament tournament)
        {
            bool res = false;
            string sqlQuery = "INSERT INTO Tournament (TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants) VALUES (@TournamentName, @TimeOfEvent, @RegistrationDeadline, @MinParticipants, @MaxParticipants)";
            var param = new
            {
                TournamentName = tournament.TournamentName,
                TimeOfEvent = tournament.TimeOfEvent,
                RegistrationDeadline = tournament.RegistrationDeadline,
                MinParticipants = tournament.MinParticipants,
                MaxParticipants = tournament.MaxParticipants
            };
            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) > 0)
                {
                    res = true;
                }
            }
            return res;
        }

        public bool UpdateItem(Tournament tournament)
        {
            bool res = false;
            string sqlQuery = "UPDATE Tournament SET TournamentName = @TournamentName, TimeOfEvent = @TimeOfEvent, RegistrationDeadline = @RegistrationDeadline, MinParticipants = @MinParticipants, MaxParticipants = @MaxParticipants WHERE TournamentId = @TournamentId";
            var param = new
            {
                TournamentName = tournament.TournamentName,
                TimeOfEvent = tournament.TimeOfEvent,
                RegistrationDeadline = tournament.RegistrationDeadline,
                MinParticipants = tournament.MinParticipants,
                MaxParticipants = tournament.MaxParticipants
            };
            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) == 1)
                {
                    res = true;
                }
            }
            return res;
        }

        public bool DeleteItem(int tournamentId)
        {
            bool res = false;
            string sqlQuery = "DELETE FROM Tournament WHERE TournamentId = @TournamentId";
            var param = new { TournamentId = tournamentId };

            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) == 1)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
