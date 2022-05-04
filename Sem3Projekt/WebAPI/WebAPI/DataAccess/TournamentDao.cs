using System.Data.SqlClient;
using System.Transactions;
using Dapper;
using Microsoft.AspNetCore.Identity;
using WebAPI.Models;
using IsolationLevel = System.Data.IsolationLevel;

namespace WebAPI.DataAccess {
	public class TournamentDao : IDao<Tournament, int> {
		private readonly SqlConnection _conn;

		public TournamentDao(SqlConnection conn) {
			_conn = conn;
		}

		public Tournament GetItemById(int personEmail) {
			Tournament foundTournament = null;
			string sqlQuery =
				"SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = personEmail };

			using (_conn) {
				foundTournament = _conn.QuerySingle<Tournament>(sqlQuery, param);
			}
			return foundTournament;
		}

		public bool EnrollInTournament(string personEmail, int tournamentId) {
			bool result = false;
			string sqlQuery = "INSERT INTO PersonInTournament (PersonEmail, TournamentId) " +
							  "VALUES (@PersonEmail, @TournamentId)";
			var param = new {
				PersonEmail = personEmail,
				TournamentId = tournamentId
			};
			using (var transaction = new TransactionScope(
				TransactionScopeOption.Required,
				new TransactionOptions { IsolationLevel = (System.Transactions.IsolationLevel) IsolationLevel.RepeatableRead },
				TransactionScopeAsyncFlowOption.Enabled))
			{
				int maxNo = CheckTournamentMaxAvailability(tournamentId);
				int participants = GetNoOfParticipants(tournamentId);

				if (maxNo > participants)
				{
					if (_conn.Execute(sqlQuery, param) > 0) {
						result = true;
					}
				}
				transaction.Complete();
			}
			return result;
		}
		public int GetNoOfParticipants(int tournamentId) {
			int result = 0;
			string sqlQuery = "SELECT COUNT(PersonEmail) FROM PersonInTournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			using (_conn) {
				result = _conn.Execute(sqlQuery, param);
			}
			return result;
		}
		public int CheckTournamentMaxAvailability(int tournamentId) {
			int participantsInTournament = 0;
			string sqlQuery = "SELECT MaxParticipants FROM Tournament WHERE TournamentId = @TournamentId";
			var param = new { TournamentId = tournamentId };
			using (_conn) {
				participantsInTournament = _conn.QuerySingle<int>(sqlQuery, param);
				
			}
			
			return participantsInTournament;
		}

		//public ParticipantsInTournament GetTournamentParticipantsAndMax(int personEmail) {
		//	ParticipantsInTournament foundParticipantsInTournament = null;
		//	string sqlQuery = "SELECT PersonEmail, TournamentId, MaxParticipants FROM ParticipantsInTournament WHERE TournamentId = @TournamentId";
		//	var param = new {
		//		TournamentId = personEmail
		//	};
		//	using (_conn) {
		//		foundParticipantsInTournament = _conn.Query<ParticipantsInTournament, string, ParticipantsInTournament>(sqlQuery,
		//			map: (foundParticipantsInTournament, string) => {
		//				if (!foundParticipantsInTournament.ParticipantEmails.TryGetValue(PersonEmail, out string personEmail)) {
		//					courseEntry = course;
		//					courseEntry.Locations = courseEntry.Locations ?? new List<Location>();
		//					courseDictionary.Add(courseEntry.Id, courseEntry);
		//				}

		//				courseEntry.Locations.Add(location);
		//				return courseEntry;
		//				return foundParticipantsInTournament.ParticipantEmails.Add(string);
		//			},
		//		param,
		//			splitOn: "");
		//	}

		//	return foundParticipantsInTournament;
		//}

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
			List<Tournament> foundTournaments = null;
			string sqlQuery = "SELECT TournamentId, TournamentName, TimeOfEvent, RegistrationDeadline, MinParticipants, MaxParticipants FROM Tournament";

			using (_conn) {
				foundTournaments = _conn.Query<Tournament>(sqlQuery).ToList();
			}
			return foundTournaments;
		}
	}
}
