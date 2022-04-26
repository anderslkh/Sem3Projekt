using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using WebAPI.DataAccess;
using WebAPI.Managers;
using WebAPI.Models;
using Xunit;

namespace TestWebAPI {
	public class TournamentTest {
		private IDao<Tournament, int> tournamentDao;
		private readonly string _connectionString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;";

		//Expected tournament from database
		private Tournament expectedTournament;
		private int tournamentId;
		private string tournamentName;
		private TournamentDescription tournamentDescription;

		private string tournamentDetails;

		//Expected tournament description
		private string gameName = "Test game";
		private DateTime timeOfEvent;
		private DateTime registrationDeadline;
		private int minParticipants;
		private int maxParticipants;

		//Actual tournament from database
		private Tournament foundTournament;

		public TournamentTest() {
			//Arrange
			tournamentDao = new TournamentDao(new SqlConnection(_connectionString));

			//Tournament info
			tournamentId = 1;
			tournamentName = "Test";
			timeOfEvent = new DateTime(2001, 01, 01, 00,00,00,000);
			registrationDeadline = new DateTime(2001, 01, 01, 00,00,00,000);
			minParticipants = 0;
			maxParticipants = 16;

			expectedTournament = new Tournament(tournamentId, tournamentName, timeOfEvent, registrationDeadline, minParticipants, maxParticipants);
			}

		[Fact]
		public void GetTournament() {
			{
				//Act
				foundTournament = tournamentDao.GetItemById(tournamentId);
				
				//Assert
				Assert.Equal(expectedTournament.TournamentId, foundTournament.TournamentId);
				Assert.Equal(expectedTournament.TournamentName, foundTournament.TournamentName);
				Assert.Equal(expectedTournament.TimeOfEvent,
					foundTournament.TimeOfEvent);
				Assert.Equal(expectedTournament.RegistrationDeadline,
					foundTournament.RegistrationDeadline);
				Assert.Equal(expectedTournament.MinParticipants,
					foundTournament.MinParticipants);
				Assert.Equal(expectedTournament.MaxParticipants,
					foundTournament.MaxParticipants);

			}
		}
	}
}
