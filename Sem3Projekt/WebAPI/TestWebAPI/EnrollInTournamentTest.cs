using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WebAPI.DataAccess;
using WebAPI.Managers;
using Xunit;

namespace TestWebAPI {
    public class EnrollInTournamentTest
    {
        private TournamentDao tournamentDao;
        private TransactionScope transaction;
        public EnrollInTournamentTest()
        {
            transaction = new TransactionScope();
            tournamentDao = new TournamentDao(new SqlConnection("Data Source = hildur.ucn.dk; Initial Catalog = dmaa0221_1089437; User Id = dmaa0221_1089437; Password = Password1!;"));
        }

        [Fact]
        public void EnrollPersonInTournament()
        {
            // Arrange
            bool result;

            // Act
            result = tournamentDao.EnrollInTournament("test@test", 1);

            // Assert
            Assert.True(result);
            
            transaction.Dispose();
        }
    }
}
