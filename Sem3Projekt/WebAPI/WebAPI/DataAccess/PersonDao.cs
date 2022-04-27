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

        public Person GetItemById(string id)
        {
            Person foundPerson = null;

            string sqlQuery = 
	            "SELECT FirstName, LastName, NickName, BirthDate, Email FROM Person where Email = @Email";

            var param = new { Email = id };
            using (_conn)
            {
                foundPerson = _conn.QuerySingle<Person>(sqlQuery, param);
            }
            return foundPerson;
        }

        public List<Person> GetAllItems()
        {
	        List<Person> foundList = null;
	        string sqlQuery = "SELECT * FROM Person";

	        using (_conn)
	        {
		        foundList = _conn.Query<Person>(sqlQuery).ToList();
	        }
	        return foundList;
        }


        public bool CreateItem(Person person)
        {
			bool result = false;
			string sqlQuery = "INSERT INTO Person (FirstName, LastName, NickName, BirthDate, Email) " +
							  "VALUES (@FirstName, @LastName, @NickName, @BirthDate, @Email)";
			var param = new
			{
				FirstName = person.firstName,
				LastName = person.lastName,
				NickName = person.nickName,
				BirthDate = person.birthDate,
				Email = person.email
			};
			using (_conn)
			{
				if (_conn.Execute(sqlQuery, param) > 0)
				{
					result = true;
				}
			}
			return result;
        }

        public bool UpdateItem(Person person)
        {
            bool res = false;
            string sqlQuery = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName, NickName = @NickName, BirthDate = @BirthDate WHERE Email = @Email";
            var param = new
            {
                FirstName = person.firstName,
                LastName = person.lastName,
                NickName = person.nickName,
                BirthDate = person.birthDate,
                Email = person.email
            };
            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) == 1) 
                {
                    res = true;
                }
            }
            return res;
        }

        public bool DeleteItem(string email)
        {
            bool res = false;
            string sqlQuery = "DELETE FROM Person WHERE Email = @Email";
            var param = new { Email = email };
            using (_conn)
            {
                if (_conn.Execute(sqlQuery, param) == 1) 
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
