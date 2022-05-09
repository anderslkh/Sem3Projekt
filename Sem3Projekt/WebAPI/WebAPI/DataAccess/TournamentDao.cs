using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Identity;
using NuGet.Versioning;
using WebAPI.Model_DTO_s;
using WebAPI.Models;

namespace WebAPI.DataAccess {
	public class TournamentDao : IDao<Tournament, int> {
		private readonly SqlConnection _conn;

		public TournamentDao(SqlConnection conn) {
			_conn = conn;
		}

		public Tournament GetItemById(int tournamentId) {
			Tournament foundTournament = null;
			string sqlQueryAdmin =
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, PersonEmail FROM TournamentInfoView WHERE TournamentId = @TournamentId";
			string sqlQueryUser = 
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, EnrolledParticipants FROM TournamentInfo WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			
			using (_conn)
			{
				var tournaments = _conn.Query<Tournament, string, Tournament>(
					sqlQueryAdmin, (tournament, personEmail) =>
					{
						tournament.ListOfParticipantIds.Add(personEmail);
						return tournament;
					}, param, splitOn: "PersonEmail");
				
					foundTournament = tournaments.GroupBy(tournament => tournament.TournamentId).Select(g =>
					{
						var groupedPost = g.First();
						groupedPost.ListOfParticipantIds = g.Select(p => p.ListOfParticipantIds.Single()).ToList();
						return groupedPost;
					}).First();
			}

			return foundTournament;
		}

		public int EnrollInTournament(int tournamentId, int enrolledParticipants, string personEmail) {
			int result = -1;
			string sqlQueryCheckAvailable = "SELECT ISNULL((SELECT 1 FROM TournamentInfo WHERE TournamentInfo.TournamentId = @TournamentId AND (TournamentInfo.EnrolledParticipants = @EnrolledParticipants)), 0)";
			string sqlQueryInsert =
				"INSERT INTO PersonInTournament (PersonEmail, TournamentId) SELECT * FROM (SELECT @PersonEmail AS PersonEmail, @TournamentId AS TournamentId) AS temp WHERE NOT EXISTS (SELECT @PersonEmail FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentId)";
			var checkParam = new
			{
				TournamentId = tournamentId,
				EnrolledParticipants = enrolledParticipants
			};

			var param = new {
				PersonEmail = personEmail,
				TournamentId = tournamentId,
			};
			using (_conn)
			{
				
				if ((int)_conn.ExecuteScalar(sqlQueryCheckAvailable, checkParam) == 1)
				{
					result = _conn.Execute(sqlQueryInsert, param);
				}
				
			}

			return result;
		}
		
		public List<Tournament> GetAllItems() {
			List<Tournament> foundTournaments = new List<Tournament>();
			string sqlQuery = "SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, PersonEmail FROM TournamentInfoView";

			using (_conn) {
				var tournaments = _conn.Query<Tournament, string, Tournament>(
					sqlQuery, (tournament, personEmail) =>
					{
						tournament.ListOfParticipantIds.Add(personEmail);
						return tournament;
					}, splitOn: "PersonEmail");
				 foundTournaments = tournaments.GroupBy(tournament => tournament.TournamentId).Select(group =>
				{
					var groupedTournaments = group.First();
					groupedTournaments.ListOfParticipantIds =
						group.Select(tournament => tournament.ListOfParticipantIds.Single()).ToList();
					return groupedTournaments;
				}).ToList();
			}
			return foundTournaments;
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
    }
}
