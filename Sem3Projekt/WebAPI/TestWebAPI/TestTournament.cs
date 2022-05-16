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

namespace TestWebAPI
{
    public class TestTournament
    {
        private ITournamentDao<EnrollmentDTO> tournamentDao;
        //private readonly string _connectionString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;";
        private int tempId;
        private string tournamentName = "testTournament";
        private DateTime timeOfEvent = new DateTime(2022, 10, 10, 00, 00, 00, 000);
        private DateTime registrationDate = new DateTime(2022, 10, 10, 00, 00, 00, 000);
        private int maxParticipants = 2;
        private int minParticipants = 0;
        private Tournament tempTournament = null;

        public TestTournament(ITournamentDao<EnrollmentDTO> tournamentDao, string connectionString)
        {
            //Arrange
            tournamentDao = new TournamentDao(new SqlConnection("Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;"));
            tempTournament = new Tournament(tournamentName, timeOfEvent, registrationDate, maxParticipants, minParticipants);
        }


        [Fact]
        public void CreateTournamentTest()
        {
            //Act
            tempId = tournamentDao.CreateItem(tempTournament);

            //Assert
            Assert.True(tempId > 0);

        }

        [Fact]
        public void GetTournamentTest()
        {
            //Arrange


            //Act
            Tournament foundTournament = tournamentDao.GetItemById(tempId);

            //Assert
            Assert.Equal(tempTournament.TournamentId, foundTournament.TournamentId);
            Assert.Equal(tempTournament.TournamentName, foundTournament.TournamentName);
            Assert.Equal(tempTournament.TimeOfEvent, foundTournament.TimeOfEvent);
            Assert.Equal(tempTournament.RegistrationDeadline, foundTournament.RegistrationDeadline);
            Assert.Equal(tempTournament.MinParticipants, foundTournament.MinParticipants);
            Assert.Equal(tempTournament.MaxParticipants, foundTournament.MaxParticipants);
        }

        [Fact]
        public void EnrollInTournamentTest()
        {
            //Arrange
            int bobIsEnrolled = -1;
            int userIsEnrolled = -1;
            EnrollmentDTO bobEnrollmentDTO = new EnrollmentDTO(tempId, 0, "bob@bob", 2);
            EnrollmentDTO userEnrollmentDTO = new EnrollmentDTO(tempId, 1, "user@user.com", 2);

            //Act
            bobIsEnrolled = tournamentDao.EnrollInTournament(bobEnrollmentDTO);
            userIsEnrolled = tournamentDao.EnrollInTournament(userEnrollmentDTO);

            //Assert
            Assert.Equal(1, bobIsEnrolled);
            Assert.Equal(1, userIsEnrolled);

        }

        [Fact]
        public void TournamentIsFullTest()
        {
            //Arrange
            int isEnrolled = -1;
            EnrollmentDTO enrollmentDTO = new EnrollmentDTO(tempId, 2, "test@test", 2);

            //Act
            isEnrolled = tournamentDao.EnrollInTournament(enrollmentDTO);

            //Assert
            Assert.Equal(-1, isEnrolled);

        }

        [Fact]
        public void DeleteTournamentTest()
        {
            //Arrange
            bool isDeleted = false;

            //Act
            isDeleted = tournamentDao.DeleteItem(tempId);

            //Assert
            Assert.True(isDeleted);

        }
    }
}
