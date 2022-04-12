using System.Data.SqlClient;
using WebAPI.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace WebAPI.DataAccess
{
    public class DaoFactory
    {
        public static IDao<Person, string> CreatePersonDao() 
        {
            return new PersonDao(GetConnection());
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
        }
    }
}
