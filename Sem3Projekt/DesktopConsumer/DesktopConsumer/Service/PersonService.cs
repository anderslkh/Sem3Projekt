using DesktopConsumer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopConsumer.Service
{
    public class PersonService
    {
        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/persons/";

        public PersonService()
        {
            _client = new HttpClient();
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            Person foundPerson = null;

            string useUrl = $"{restUrl}{email}/";

            var uri = new Uri(useUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                { 
                    var content = await response.Content.ReadAsStringAsync(); 
                    foundPerson = JsonConvert.DeserializeObject<Person>(content);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return foundPerson;
        }
    }
}
