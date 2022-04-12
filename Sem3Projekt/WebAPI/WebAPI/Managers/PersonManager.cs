using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers
{
    public class PersonManager : IPersonManager
    {
        public Person GetPersonByEmail(string email)
        {
            Person foundPerson = null;
            IDao<Person, string> personDao = DaoFactory.CreatePersonDao();
            try
            {
                foundPerson = personDao.GetById(email);
            }
            catch (Exception)
            {

                throw;
            }
            return foundPerson;
        }
    }
}
