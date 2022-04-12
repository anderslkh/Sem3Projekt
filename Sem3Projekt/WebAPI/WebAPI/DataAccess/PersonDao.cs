using Dapper;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class PersonDao : IDao<Person, string>
    {
        private SqlConnection conn;

        public PersonDao(SqlConnection conn)
        {

            this.conn = conn;
        }

        public Person GetById(string id)
        {
            Person foundPerson = null;

            string queryString = "SELECT FirstName, LastName, NickName, BirthDate, Email FROM Person where Email = @Email";

            var param = new { Email = id };
            using (conn)
            {
                foundPerson = conn.QuerySingle<Person>(queryString, param);
            }
            return foundPerson;
        }
    }
}
