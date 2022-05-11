using Dapper;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class PersonDao : IDao<Person, string>
    {
        private readonly SqlConnection _conn;

        public PersonDao(SqlConnection conn)
        {

            _conn = conn;
        }

        public Person GetItemById(string personEmail)
        {
            Person foundPerson = null;

            string sqlQuery = 
	            "SELECT FirstName, LastName, BirthDate, Email, UserName FROM PersonView where Email = @Email";

            var param = new { Email = personEmail };
            using (_conn)
            {
                foundPerson = _conn.QuerySingle<Person>(sqlQuery, param);
            }
            return foundPerson;
        }

        public List<Person> GetAllItems()
        {
	        List<Person> foundList = null;
	        string sqlQuery = "SELECT * FROM PersonView";

	        using (_conn)
	        {
		        foundList = _conn.Query<Person>(sqlQuery).ToList();
	        }
	        return foundList;
        }
        public bool CreateItem(Person person) {



	        bool result = false;
	        string sqlQuery = "INSERT INTO Person (FirstName, LastName, BirthDate, Email) " +
	                          "VALUES (@FirstName, @LastName, @BirthDate, @Email)";
	        var param = new {
		        FirstName = person.FirstName,
		        LastName = person.LastName,
		        BirthDate = person.BirthDate,
		        Email = person.Email
	        };
	        using (_conn) {
		        if (_conn.Execute(sqlQuery, param) > 0) {
			        result = true;
		        }
	        }
	        return result;
        }

        public bool DeleteItem(string id)
        {
            throw new NotImplementedException();
        }
    }
}
