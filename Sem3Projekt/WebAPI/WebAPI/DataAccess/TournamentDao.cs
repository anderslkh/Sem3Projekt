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

		public Tournament GetById(int tournamentId)
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

		public List<Tournament> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
