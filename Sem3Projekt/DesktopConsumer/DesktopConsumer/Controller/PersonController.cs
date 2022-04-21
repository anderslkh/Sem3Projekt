using DesktopConsumer.Models;
using DesktopConsumer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopConsumer.Controller
{
    public class PersonController
    {
        private PersonService personService;

        public PersonController()
        {
            personService = new PersonService();  
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
           return await personService.GetPersonByEmail(email);
        }
    }
}
