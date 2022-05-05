using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Identity;
using NuGet.Versioning;
using WebAPI.Models;

namespace WebAPI.DataAccess {
	public class TournamentDao : IDao<Tournament, int> {
		private readonly SqlConnection _conn;

		public TournamentDao(SqlConnection conn) {
			_conn = conn;
		}

		public Tournament GetItemById(int tournamentId) {
			Tournament foundTournament = null;
			string sqlQuery =
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants, PersonEmail FROM TournamentInfoView WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			
			using (_conn)
			{
				var tournaments = _conn.Query<Tournament, string, Tournament>(
					sqlQuery, (tournament, personEmail) =>
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
			string sqlQuery =
				"INSERT INTO PersonInTournament (PersonEmail, TournamentId) SELECT * FROM (SELECT @PersonEmail AS PersonEmail, @TournamentId AS TournamentId) AS temp WHERE NOT EXISTS (SELECT @PersonEmail FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentId)";
			//"SELECT * FROM (SELECT 'bob@bob' AS PersonEmail, 1 AS TournamentId) AS temp WHERE NOT EXISTS (SELECT 'bob@bob' FROM PersonInTournament WHERE PersonEmail = 'bob@bob')";
			//string sqlQuery = "INSERT INTO PersonInTournament (PersonEmail, TournamentId) " +
			//                  "SELECT @PersonEmail AND @TournamentId WHERE NOT EXISTS (" +
			//                  "SELECT * FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentID)";
			//string q = "INSERT INTO PersonInTournament (PersonEmail, TournamentId)" +
			//"SELECT * FROM(SELECT @PersonEmail AS PersonEmail, @TournamentId AS TournamentId) AS temp" +
			//"WHERE NOT EXISTS( SELECT @PersonEmail FROM PersonEmail WHERE PersonEmail = @PersonEmail) LIMIT 1"; 
			var param = new {
				PersonEmail = personEmail,
				TournamentId = tournamentId
			};
			using (_conn) {
				result = _conn.Execute(sqlQuery, param);
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
	}
}
