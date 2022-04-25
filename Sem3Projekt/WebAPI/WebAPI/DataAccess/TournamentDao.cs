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

		public Tournament GetById(int id)
		{
			Tournament foundTournament = null;
			string sqlQuery=
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinTeams, MaxTeams FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new {TournamentId = id};
			
			using (_conn)
			{
				foundTournament = _conn.QuerySingle<Tournament>(sqlQuery, param);

			}

			return foundTournament;
		}

		public List<Tournament> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
