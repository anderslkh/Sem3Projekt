using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using WebAPI.Managers;
using WebAPI.Models;
using Xunit;

namespace TestWebAPI {
	//public class TournamentTest {
	//	private IManager<Tournament, int> tournamentManager;


	//	//Expected tournament from database
	//	private Tournament expectedTournament;
	//	private int tournamentId;
	//	private string tournamentName;
	//	private TournamentDescription tournamentDescription;

	//	private string tournamentDetails;

	//	//Expected tournament description
	//	private string gameName = "Test game";
	//	private DateTime timeOfEvent;
	//	private DateTime registrationDeadline;
	//	private int minTeams;
	//	private int maxTeams;

	//	//Actual tournament from database
	//	private Tournament foundTournament;

	//	//public TournamentTest() {
	//	//	//Arrange
	//	//	tournamentManager = ManagerFactory.CreateTournamentManager();

	//	//	//Tournament info
	//	//	tournamentId = 1;
	//	//	tournamentName = "Test Tournament";
	//	//	tournamentDetails = "Details og tournament";

	//	//	//Tournament description info
	//	//	timeOfEvent = new DateTime(2022, 10, 10, 12, 00, 00);
	//	//	registrationDeadline = new DateTime(2022, 10, 10, 08, 00, 00);
	//	//	minTeams = 8;
	//	//	maxTeams = 16;

	//	//	//Create & Combine
	//	//	tournamentDescription = new TournamentDescription(gameName, tournamentDetails, minTeams, maxTeams);
	//	//	expectedTournament = new Tournament(tournamentId, tournamentName, timeOfEvent, registrationDeadline);
	//	//	expectedTournament.TournamentDescription = tournamentDescription;
	//	//}

	//	[Fact]
	//	//public void GetTournament() {
	//	//	{
	//	//		//Act
	//	//		foundTournament = tournamentManager.GetById(tournamentId);
	//	//		//Assert
	//	//		Assert.Equal(expectedTournament.TournamentId, foundTournament.TournamentId);
	//	//		Assert.Equal(expectedTournament.TournamentName, foundTournament.TournamentName);
	//	//		Assert.Equal(expectedTournament.TournamentDescription.TournamentDetails, foundTournament.TournamentDescription.TournamentDetails);
	//	//		Assert.Equal(expectedTournament.TournamentDescription.GameName,
	//	//			foundTournament.TournamentDescription.GameName);
	//	//		Assert.Equal(expectedTournament.TimeOfEvent,
	//	//			foundTournament.TimeOfEvent);
	//	//		Assert.Equal(expectedTournament.RegistrationDeadline,
	//	//			foundTournament.RegistrationDeadline);
	//	//		Assert.Equal(expectedTournament.TournamentDescription.MinNoOfParticipant,
	//	//			foundTournament.TournamentDescription.MinNoOfParticipant);
	//	//		Assert.Equal(expectedTournament.TournamentDescription.MaxNoOfParticipant,
	//	//			foundTournament.TournamentDescription.MaxNoOfParticipant);

	//	//	}
	//	//}
	//}
}
