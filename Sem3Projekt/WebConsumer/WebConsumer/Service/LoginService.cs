using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using WebConsumer.Models;

namespace WebConsumer.Service {
    public class LoginService {

        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/authenticate/";

        public LoginService()
        {
            _client = new HttpClient();
        }

        public async Task<string> Login(string username, string password)
        {
            Person newPerson = new Person(username, password);
            string useUrl = $"{restUrl}login";
            var uri = new Uri(useUrl);
            string result = "";
            try
            {
                var response = await _client.PostAsJsonAsync(uri, newPerson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = content;

                }

            }
            catch (Exception) {
                throw;
            }
            return result;
        }
    }
}
