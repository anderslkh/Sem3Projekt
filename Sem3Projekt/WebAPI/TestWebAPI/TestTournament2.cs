using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using Xunit;
using WebAPI.Models;
using WebAPI.ModelDTOs;
using Xunit.Priority;

namespace TestWebAPI
{
    public class TestTournament2
    {
        private TournamentDao tournamentDao;

        private int tempId;
        private string tournamentName = "testTournament";
        private DateTime timeOfEvent = new DateTime(2022, 10, 10, 00, 00, 00, 000);
        private DateTime registrationDate = new DateTime(2022, 10, 10, 00, 00, 00, 000);
        private int maxParticipants = 2;
        private int minParticipants = 0;
        private Tournament tempTournament = null;
        private readonly string _connectionString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;";

        public TestTournament2()
        {
            //Arrange
            tempTournament = new Tournament(tournamentName, timeOfEvent, registrationDate, minParticipants, maxParticipants);
        }

        [Fact]
        public void TournamentCRUDTest()
        {
            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));

            //Act
            tempId = tournamentDao.CreateItem(tempTournament);
            //Assert
            //Assert.True(tempId > 0);


            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));

            //Act
            Tournament foundTournament = tournamentDao.GetItemById(tempId);

            //Assert
            //Assert.Equal(tempTournament.TournamentId, foundTournament.TournamentId);
            //Assert.Equal(tempTournament.TournamentName, foundTournament.TournamentName);
            //Assert.Equal(tempTournament.TimeOfEvent, foundTournament.TimeOfEvent);
            //Assert.Equal(tempTournament.RegistrationDeadline, foundTournament.RegistrationDeadline);
            //Assert.Equal(tempTournament.MinParticipants, foundTournament.MinParticipants);
            //Assert.Equal(tempTournament.MaxParticipants, foundTournament.MaxParticipants);


            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));
            int bobIsEnrolled = -1;
            EnrollmentDTO bobEnrollmentDTO = new EnrollmentDTO(tempId, 0, "bob@bob", 2);

            //Act
            bobIsEnrolled = tournamentDao.EnrollInTournament(bobEnrollmentDTO);

            //Assert
            //Assert.Equal(1, bobIsEnrolled);



            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));

            int userIsEnrolled = -1;

            EnrollmentDTO userEnrollmentDTO = new EnrollmentDTO(tempId, 1, "user@user.com", 2);

            //Act

            userIsEnrolled = tournamentDao.EnrollInTournament(userEnrollmentDTO);

            //Assert

            //Assert.Equal(1, userIsEnrolled);



            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));
            int isEnrolled = -1;
            EnrollmentDTO enrollmentDTO = new EnrollmentDTO(tempId, 2, "test@test", 2);

            //Act
            isEnrolled = tournamentDao.EnrollInTournament(enrollmentDTO);

            //Assert
            //Assert.Equal(-1, isEnrolled);



            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection(_connectionString));
            bool isDeleted = false;

            //Act
            isDeleted = tournamentDao.DeleteItem(tempId);

            //Assert
            //Assert.True(isDeleted);




            //Assert
            Assert.True(tempId > 0);


            Assert.Equal(tempId, foundTournament.TournamentId);
            Assert.Equal(tempTournament.TournamentName, foundTournament.TournamentName);
            Assert.Equal(tempTournament.TimeOfEvent, foundTournament.TimeOfEvent);
            Assert.Equal(tempTournament.RegistrationDeadline, foundTournament.RegistrationDeadline);
            Assert.Equal(tempTournament.MinParticipants, foundTournament.MinParticipants);
            Assert.Equal(tempTournament.MaxParticipants, foundTournament.MaxParticipants);

            Assert.Equal(1, bobIsEnrolled);

            Assert.Equal(1, userIsEnrolled);

            Assert.Equal(-1, isEnrolled);

            Assert.True(isDeleted);
        }
    }
}
