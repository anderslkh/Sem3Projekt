using System.Net.Http.Headers;
using WebConsumer.Models;

namespace WebConsumer.Service {
    public class LoginService {

        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/authenticate/";

        public LoginService()
        {
            _client = new HttpClient();
        }

        public async Task<int> Register(RegisterModel registerPerson)
        {
            string useUrl = $"{restUrl}register";
            var uri = new Uri(useUrl);
            int result = -1;
            try
            {
                var response = await _client.PostAsJsonAsync(uri, registerPerson);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    result = Int32.Parse(content.Result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<string> Login(Person person)
        {
            string useUrl = $"{restUrl}login";
            var uri = new Uri(useUrl);
            string result = "";
            try
            {
                var response = await _client.PostAsJsonAsync(uri, person);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = content;
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content);
                }

            }
            catch (Exception) {
                throw;
            }
            return result;
        }
    }
}
