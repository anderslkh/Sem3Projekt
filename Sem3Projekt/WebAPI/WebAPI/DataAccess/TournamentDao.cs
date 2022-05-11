using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Identity;
using NuGet.Versioning;
using WebAPI.Model_DTO_s;
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
				// Retrieves a resultset with information about the tournament, in a row for each email in the tournament.
				var tournaments = _conn.Query<Tournament, string, Tournament>(
					sqlQueryAdmin, (tournament, personEmail) =>
					{
						tournament.ListOfParticipantIds.Add(personEmail);
						return tournament;
					}, param, splitOn: "PersonEmail");

				// Now the resultset has to be grouped by tournament id, meaning that the emails needs to be listed.
				foundTournament = tournaments.GroupBy(tournament => tournament.TournamentId).Select(g =>
					{
						var groupedPost = g.First();
						groupedPost.ListOfParticipantIds = g.Select(p => p.ListOfParticipantIds.Single()).ToList();
						return groupedPost;
					}).First();
				// These are returned as an IEnumerable of tournaments, since there is only one, we take the first from the list.
			}

			return foundTournament;
		}

		public int EnrollInTournament(EnrollmentDTO enrollmentDto) 
		{
			int result = -1;
			// SQL statement to check if the tourament has room to enroll.
			string sqlQueryCheckAvailable = "SELECT ISNULL((SELECT 1 FROM TournamentInfo " +
			                                "WHERE TournamentInfo.TournamentId = @TournamentId " +
			                                "AND (TournamentInfo.EnrolledParticipants >= @EnrolledParticipants) " +
			                                "AND (TournamentInfo.MaxParticipants > TournamentInfo.EnrolledParticipants)), 0)";
				//"SELECT ISNULL((SELECT 1 FROM TournamentInfo WHERE TournamentInfo.TournamentId = @TournamentId AND (TournamentInfo.EnrolledParticipants = @EnrolledParticipants)), 0)";

			// SQL statement to insert (Enroll) the user into the tournament, if the user does NOT already exist in the tournament.
			string sqlQueryInsert =
				"INSERT INTO PersonInTournament (PersonEmail, TournamentId) SELECT * FROM (SELECT @PersonEmail AS PersonEmail, @TournamentId AS TournamentId) AS temp WHERE NOT EXISTS (SELECT @PersonEmail FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentId)";
			var checkParam = new
			{
				TournamentId = enrollmentDto.TournamentId,
				EnrolledParticipants = enrollmentDto.EnrolledParticipants
			};

			var param = new 
			{
				PersonEmail = enrollmentDto.PersonEmail,
				TournamentId = enrollmentDto.TournamentId,
			};
			//no isolation level is needed here because nothing is being modified in the DB, only insert is made
            using (TransactionScope scope = new TransactionScope())
			{
				using (_conn)
				// The if statement checks if the number of enrolled participants in the tournament
				// has changed since the user retrieved the tournament information.
				// Is false if the actual number of enrolled participants are less than max,
				// and less than or equal to what the user recieved.
				if ((int)_conn.ExecuteScalar(sqlQueryCheckAvailable, checkParam) == 1)
				{
					// The if statement checks if the number of enrolled participants in the tournament
					// has changed since the user retrieved the tournament information.
					// Is false if the actual number of enrolled participants are less than max,
					// and less than or equal to what the user recieved.
					int check = (int)_conn.ExecuteScalar(sqlQueryCheckAvailable, checkParam);
					if (check == 1)
					{
						result = _conn.Execute(sqlQueryInsert, param);
					}
                    else
                    {
						throw new Exception();
                    }
				}
				scope.Complete();
			}
			return result;
		}
		
		public List<Tournament> GetAllItems() 
		{
			List<Tournament> foundTournaments = new List<Tournament>();
			string sqlQuery = "SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, EnrolledParticipants FROM TournamentInfo";
            using (_conn) {
                //var tournaments = _conn.Query<Tournament, string, Tournament>(
                //    sqlQuery, (tournament, personEmail) => {
                //        tournament.ListOfParticipantIds.Add(personEmail);
                //        return tournament;
                //    }, splitOn: "PersonEmail");
                //foundTournaments = tournaments.GroupBy(tournament => tournament.TournamentId).Select(group => {
                //    var groupedTournaments = group.First();
                //    groupedTournaments.ListOfParticipantIds =
                //        group.Select(tournament => tournament.ListOfParticipantIds.Single()).ToList();
                //    return groupedTournaments;
                //}).ToList();
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

		public bool CreateItem(TournamentDTO itemToCreate)
        {
			bool result = false;
            string sqlQuery = "INSERT INTO Tournament (TimeOfEvent, RegistrationDeadline, TournamentName, MinParticipants, MaxParticipants) " +
                              "VALUES (@TimeOfEvent, @RegistrationDeadline, @TournamentName, @MinParticipants, @MaxParticipants)";
            var param = new {
                TimeOfEvent = itemToCreate.TimeOfEvent,
				RegistrationDeadline = itemToCreate.RegistrationDeadline,
				TournamentName = itemToCreate.TournamentName,
				MinParticipants = itemToCreate.MinNoOfParticipants,
				MaxParticipants = itemToCreate.MaxNoOfParticipants
            };
            using (_conn) {
                if (_conn.Execute(sqlQuery, param) > 0) {
                    result = true;
                }
            }
            return result;
			
		}

		public bool DeleteItem(int tournamentId)
		{
			bool res = false;
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
