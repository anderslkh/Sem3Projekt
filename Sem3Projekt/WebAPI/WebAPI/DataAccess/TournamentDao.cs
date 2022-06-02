using System.Data.SqlClient;
using Dapper;
using WebAPI.Models;
using WebAPI.ModelDTOs;
using System.Transactions;

namespace WebAPI.DataAccess {
	public class TournamentDao : ITournamentDao<EnrollmentDTO> 
	{
		private readonly SqlConnection _conn;

		public TournamentDao(SqlConnection conn) 
		{
			_conn = conn;
		}

		public Tournament GetItemById(int tournamentId) 
		{
			Tournament foundTournament = null;
			// SQL statement to get a tournament with emails (Id´s) of participants.
			// Not yet implemented.
			string sqlQueryAdmin =
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, PersonEmail FROM TournamentInfoView WHERE TournamentId = @TournamentId";
			// SQL statement to get at Tournament with number of enrolled participants from view.
			string sqlQueryUser = 
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, EnrolledParticipants FROM TournamentInfo WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };

			using (_conn)
            {
                foundTournament = _conn.QuerySingle<Tournament>(sqlQueryUser, param);

				// Retrieves a resultset with information about the tournament, in a row for each email in the tournament.
				//var tournaments = _conn.Query<Tournament, string, Tournament>(
				//	sqlQueryUser, (tournament, personEmail) =>
				//	{
				//		//tournament.ListOfParticipantIds.Add(personEmail);
				//		return tournament;
				//	}, param, splitOn: "PersonEmail");

				// Now the resultset has to be grouped by tournament id, meaning that the emails needs to be listed.
				//foundTournament = tournaments.GroupBy(tournament => tournament.TournamentId).Select(g =>
				//	{
				//		var groupedPost = g.First();
				//		groupedPost.ListOfParticipantIds = g.Select(p => p.ListOfParticipantIds.Single()).ToList();
				//		return groupedPost;
				//	}).First();
				// These are returned as an IEnumerable of tournaments, since there is only one, we take the first from the list.
			}

			return foundTournament;
		}

		public int EnrollInTournament(EnrollmentDTO enrollmentDto) 
		{
			int result = -1;
			// SQL statement to check if the tourament has room to enroll.
			string sqlQueryCheckAvailable = "UPDATE Tournament SET EnrolledParticipants +=1 WHERE TournamentId = @TournamentId AND MaxParticipants > EnrolledParticipants";
				//"SELECT ISNULL((SELECT 1 FROM TournamentInfo WHERE TournamentInfo.TournamentId = @TournamentId AND (TournamentInfo.EnrolledParticipants = @EnrolledParticipants)), 0)";
                // SQL statement to insert (Enroll) the user into the tournament, if the user does NOT already exist in the tournament.
			string sqlQueryInsert = "INSERT INTO PersonInTournament(PersonEmail, TournamentId) SELECT* FROM(SELECT @PersonEmail AS PersonEmail, @TournamentId AS TournamentId) AS temp WHERE NOT EXISTS(SELECT @PersonEmail FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentId)";
            var checkParam = new
			{
				TournamentId = enrollmentDto.TournamentId
				// Er ikke brugt i denne implementation, kig linje 58
                //MaxParticipants = enrollmentDto.MaxParticipants,
                //EnrolledParticipants = enrollmentDto.EnrolledParticipants
			};

			var param = new 
			{
				enrollmentDto.PersonEmail,
				enrollmentDto.TournamentId,
			};

			// Default level is SERIALIZABLE ?!?!?!?!? (╯°□°）╯︵ ┻━┻
			// https://docs.microsoft.com/en-us/dotnet/api/system.transactions.isolationlevel?view=netframework-4.7.2
			// 

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = IsolationLevel.ReadUncommitted;
			using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions)) 
			{
                using (_conn)
                {
	                // The if statement checks if the number of enrolled participants in the tournament
                    // has changed since the user retrieved the tournament information.
                    // Is false if the actual number of enrolled participants are less than max,
                    // and less than or equal to what the user recieved.
                    if ((int) _conn.Execute(sqlQueryCheckAvailable, checkParam) == 1)
                    {
                        result = _conn.Execute(sqlQueryInsert, param);
                    }
                }
                if (result == 1) {
                    scope.Complete();
                }
			}
			// Hvis ikke scope.Complete() ses indenfor using(scope) så laves et rollback
			return result;
		}
		
		public List<Tournament> GetAllItems() 
		{
			List<Tournament> foundTournaments = new List<Tournament>();
			string sqlQuery = "SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, EnrolledParticipants FROM TournamentInfo";
            using (_conn) {
                //var tournaments = _conn.query<tournament, string, tournament>(
                //    sqlquery, (tournament, personemail) => {
                //        tournament.listofparticipantids.add(personemail);
                //        return tournament;
                //    }, spliton: "personemail");
                //foundtournaments = tournaments.groupby(tournament => tournament.tournamentid).select(group => {
                //    var groupedtournaments = group.first();
                //    groupedtournaments.listofparticipantids =
                //        group.select(tournament => tournament.listofparticipantids.single()).tolist();
                //    return groupedtournaments;
                //}).tolist();
                foundTournaments = _conn.Query<Tournament>(sqlQuery).ToList();
            }
			return foundTournaments;
            //using (_conn) 
            //{
            //	// Retrieves a resultset with information about the tournament, in a row for each email in the tournament.
            //	var tournaments = _conn.Query<Tournament, string, Tournament>(
            //		sqlQuery, (tournament, personEmail) =>
            //		{
            //			tournament.ListOfParticipantIds.Add(personEmail);
            //			return tournament;
            //		}, splitOn: "PersonEmail");

            //	// Now the resultset has to be grouped by tournament id, meaning that the emails needs to be listed.
            //	foundTournaments = tournaments.GroupBy(tournament => tournament.TournamentId).Select(
            //		group =>
            //		{
            //			var groupedTournaments = group.First();
            //			groupedTournaments.ListOfParticipantIds =
            //				group.Select(tournament => tournament.ListOfParticipantIds.Single()).ToList();
            //			return groupedTournaments;
            //		}).ToList();
            //	// These are returned as an IEnumerable of tournaments, therefor we cast to list.

            //}
            //return foundTournaments;
		}

		public int CreateItem(Tournament itemToCreate) {
			int id = -1;
			string sqlQuery = "INSERT INTO Tournament (TournamentName, MinParticipants, MaxParticipants, TimeOfEvent, RegistrationDeadline, EnrolledParticipants) " +
								"OUTPUT INSERTED.TournamentId " +
							  "VALUES (@TournamentName, @MinParticipants, @MaxParticipants, @TimeOfEvent, @RegistrationDeadline, @EnrolledParticipants)";
			var param = new {
				itemToCreate.TimeOfEvent,
				itemToCreate.RegistrationDeadline,
				itemToCreate.TournamentName,
				itemToCreate.MinParticipants,
				itemToCreate.MaxParticipants,
				itemToCreate.EnrolledParticipants
			};
			using (_conn) {
				id = _conn.QuerySingle<int>(sqlQuery, param);
				//if (_conn.ExecuteScalar(sqlQuery, param) > 0) {
				//    result = true;
				//}
			}
			return id;
		}

		public bool DeleteItem(int tournamentId)
		{
			bool res = false;
			// Der slettes brugere som har en foreign key til TournamentId, ellers kan turneringen ikke slettes
			string sqlQueryJoinTable = "DELETE FROM PersonInTournament WHERE TournamentId = @TournamentId";
			string sqlQuery = "DELETE FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			var transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = IsolationLevel.RepeatableRead;
			using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
				using (_conn)
				{
					_conn.Execute(sqlQueryJoinTable, param);
					if (_conn.Execute(sqlQuery, param) == 1)
					{
						res = true;
					}
				}
				scope.Complete();
			}
			return res;
		}
    }
}
