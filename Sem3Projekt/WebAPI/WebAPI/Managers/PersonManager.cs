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
	    public bool CreatePerson(string firstname, string lastname, string nickname, DateTime birthDate, string email) {
		    bool result = false;
		    Person createPerson = new Person(firstname, lastname, nickname, birthDate, email);
		    PersonDao personDao = (PersonDao)DaoFactory.CreatePersonDao();
		    try {
			    result = personDao.CreatePerson(createPerson);
		    } catch (Exception e) {
			    Console.WriteLine(e);
			    throw;
		    }

		    return result;
	    }
	}
}
