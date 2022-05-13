using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WebAPI.DataAccess;
using WebAPI.Managers;
using WebAPI.ModelDTOs;
using WebAPI.Models;
using Xunit;

namespace TestWebAPI
{
    public class EnrollmentIntoTournamentTest
    {
        private TournamentDao tournamentDao;
        private TransactionScope transaction;

        public EnrollmentIntoTournamentTest()
        {
            tournamentDao = new TournamentDao(new SqlConnection("Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;"));
        }
        [Fact]
        public void EnrollIntoTournamentTest()
        {
            {
                //Arrange
                int isEnrolled = -1;
                EnrollmentDTO enrollmentDTO = new EnrollmentDTO(5, 1, "bob@bob", 16);

                //Act
                isEnrolled = tournamentDao.EnrollInTournament(enrollmentDTO);

                //Assert
                Assert.Equal(1, isEnrolled);
            }
            //transaction.Dispose();
        }

        [Fact]
        public void GetNoOfParticipantsTest()
        {
            //Arrange
            int noOfParticipants;

            //Act
            noOfParticipants = tournamentDao.GetItemById(5).EnrolledParticipants;

            //Assert
            Assert.Equal(1, noOfParticipants);

            
        }

        [Fact]
        public void TournamentFullTest()
        {

            //Arrange
            int isEnrolled = -1;
            //Tournament foundTournament = tournamentDao.GetItemById(1);
            //EnrollmentDTO enrollmentDTO = new EnrollmentDTO(foundTournament.TournamentId, foundTournament.EnrolledParticipants, "bob@bob", foundTournament.MaxParticipants);
            EnrollmentDTO enrollmentDTO = new EnrollmentDTO(1, 2, "bob@bob", 2);

            //Act
            isEnrolled = tournamentDao.EnrollInTournament(enrollmentDTO);

            //Assert
            Assert.Equal(-1, isEnrolled);
        }

    }

}
