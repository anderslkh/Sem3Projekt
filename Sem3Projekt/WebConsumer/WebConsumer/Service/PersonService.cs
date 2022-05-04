using WebConsumer.Models;
using Newtonsoft.Json;

namespace WebConsumer.Service
{
    public class PersonService : IService<Person, string>
    {
        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/persons/";

        public PersonService()
        {
            _client = new HttpClient();
        }
        public async Task<Person> GetItem(string email)
        {
            Person foundPerson = null;
            string useUrl =$"{restUrl}{email}/";
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
            catch (BadHttpRequestException ex)
            {
                throw ex;
            }
            return foundPerson;

        }

        public async Task<List<Person>> GetAllItems()
        {
	        List<Person> foundPersons = null;
	        string useUrl = $"{restUrl}";
	        var uri = new Uri(useUrl);
	        try {
		        var response = await _client.GetAsync(uri);
		        if (response.IsSuccessStatusCode) {
			        var content = await response.Content.ReadAsStringAsync();
			        foundPersons = JsonConvert.DeserializeObject<List<Person>>(content);
		        }
	        } catch (Exception ex) {
		        throw;
	        }
	        return foundPersons;
        }
    }

}
