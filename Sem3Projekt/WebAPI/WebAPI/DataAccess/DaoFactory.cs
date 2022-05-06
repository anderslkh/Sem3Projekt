using System.Data.SqlClient;
using WebAPI.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace WebAPI.DataAccess
{
    public class DaoFactory
    {

	    private static bool isTest = false;
        public static IDao<Person, string> CreatePersonDao() 
        {
            return new PersonDao(GetConnection());
        }

        public static IDao<Tournament, int> CreateTournamentDao()
        {
	        return new TournamentDao(GetConnection());
        }

        private static SqlConnection GetConnection()
        {
	        if (isTest)
	        {
		        return new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString);
	        }
            return new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
        }
    }
}
