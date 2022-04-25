using Dapper;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.DataAccess {
    public class TournamentDao : IDao<Tournament, int> {

        private SqlConnection conn;

        public TournamentDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool EnrollInTournament(string personEmail, int tournamentId)
        {
            bool result = false;
            string sqlQuery = "INSERT INTO PersonInTournament (PersonEmail, TournamentId) " +
                              "VALUES (@PersonEmail, @TournamentId)";
            var param = new
            {
                PersonEmail = personEmail,
                TournamentId = tournamentId
            };
            using (conn)
            {
                if (conn.Execute(sqlQuery, param) > 0)
                {
                    result = true;
                }

                return result;
            }
        }

        public Tournament GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tournament> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
