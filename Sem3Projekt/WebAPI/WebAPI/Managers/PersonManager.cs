﻿using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Managers
{
    public class PersonManager : IManager<Person, string>
    {

	    public Person GetItemById(string email)
        {

	        Person foundPerson = null;
	        IDao<Person, string> personDao = DaoFactory.CreatePersonDao();
	        try {
		        foundPerson = personDao.GetItemById(email);
	        } catch (Exception) {

		        throw;
	        }
	        return foundPerson;
        }

	    public List<Person> GetAllItems()
	    {
		    List<Person> foundList = null;
		    IDao<Person, string> personDao = DaoFactory.CreatePersonDao();
		    try
		    {
			    foundList = personDao.GetAllItems();
		    }
		    catch (BadHttpRequestException e)
		    {
			    Console.WriteLine(e);
			    throw;
		    }

		    return foundList;
	    }
	    public bool CreateItem(Person person) 
		{
		    bool result = false;
		    PersonDao personDao = (PersonDao)DaoFactory.CreatePersonDao();
		    try {
				if (personDao.CreateItem(person) == 1) 
				{
					result = true;
				}
			} catch (Exception e) {
			    Console.WriteLine(e);
			    throw;
		    }

		    return result;
	    }

        public bool DeleteItem(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
