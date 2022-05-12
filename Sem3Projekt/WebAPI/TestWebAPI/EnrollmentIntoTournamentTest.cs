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
            //Arrange
            int isEnrolled =-1;
            EnrollmentDTO enrollmentDTO = new EnrollmentDTO(5, 0, "user@user.com", 16);

            //Act
            isEnrolled = tournamentDao.EnrollInTournament(enrollmentDTO);

            //Assert
            Assert.Equal(1, isEnrolled);
            
        }

        [Fact]
        public void GetNoOfParticipantsTest()
        {
            //Arrange
            //int noOfParticipants;

            //Act
            //noOfParticipants = tournamentDao

            //Assert
            //Assert.Equal(1, noOfParticipants);


        }

    }

}
