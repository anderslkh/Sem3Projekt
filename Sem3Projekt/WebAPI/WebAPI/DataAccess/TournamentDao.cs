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
			string sqlQuery = "INSERT INTO PersonInTournament (PersonEmail, TournamentId) " +
							  "VALUES (@PersonEmail, @TournamentId)";
			var param = new {
				PersonEmail = personEmail,
				TournamentId = tournamentId
			};
			using (_conn) {
				result = _conn.Execute(sqlQuery, param);
			}

			return result;
		}
		public int GetNoOfParticipants(int tournamentId) {
			int result = -1;
			string sqlQuery = "SELECT COUNT(PersonEmail) FROM PersonInTournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			using (_conn) {
				result = _conn.Execute(sqlQuery, param);
			}
			return result;
		}
		public int CheckTournamentMaxAvailability(int tournamentId) {
			int participantsInTournament = -1;
			string sqlQuery = "SELECT MaxParticipants FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			using (_conn) {
				participantsInTournament = _conn.QuerySingle<int>(sqlQuery, param);
				
			}
			
			return participantsInTournament;
		}

		public bool IsParticipant(string personEmail, int tournamentId) {
			bool result = false;
			string mail = "";
			string sqlQuery = "SELECT PersonEmail FROM PersonInTournament WHERE PersonEmail = @PersonEmail AND TournamentId = @TournamentId";
			var param = new {
				PersonEmail = personEmail,
				TournamentId = tournamentId
			};
			using (_conn)
			{
				var value = _conn.ExecuteScalar(sqlQuery, param);
				if (value != null)
				{
					mail = value.ToString();
				}

			}
			if (mail.Equals(personEmail)) {
				result = true;
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
