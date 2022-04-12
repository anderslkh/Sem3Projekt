using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers
{
    public class PersonManager : IManager<Person, string>
    {

	    public Person GetById(string email)
        {

	        Person foundPerson = null;
	        IDao<Person, string> personDao = DaoFactory.CreatePersonDao();
	        try {
		        foundPerson = personDao.GetById(email);
	        } catch (Exception) {

		        throw;
	        }
	        return foundPerson;
        }

	    public List<Person> GetAll()
	    {
		    List<Person> foundList = null;
		    IDao<Person, string> personDao = DaoFactory.CreatePersonDao();
		    try
		    {
			    foundList = personDao.GetAll();
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine(e);
			    throw;
		    }

		    return foundList;
	    }
    }
}
