using System.Net.Http.Headers;
using DesktopConsumer.Models;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

namespace DesktopConsumer.Service {
    public class LoginService {

        private readonly HttpClient _client;
        private static readonly string restUrl = "https://localhost:7276/api/authenticate/";

        public LoginService()
        {
            _client = new HttpClient();
        }

        //public async Task<int> Register(RegisterModel registerPerson)
        //{
        //    string useUrl = $"{restUrl}register";
        //    var uri = new Uri(useUrl);
        //    int result = -1;
        //    try
        //    {
        //        var response = await _client.PostAsJsonAsync(uri, registerPerson);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = response.Content.ReadAsStringAsync();
        //            result = Int32.Parse(content.Result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return result;
        //}

        public async Task<string> Login(ApiAccount loginPerson)
        {
            string useUrl = $"{restUrl}login";
            var uri = new Uri(useUrl);
            string result = "";
            try
            {
                var response = await _client.PostAsJsonAsync(uri, loginPerson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = content;
                    //if (!string.IsNullOrWhiteSpace(result)) {
                    //    JObject ResultObject = JObject.Parse(result);
                    //    JToken jt = ResultObject["token"];
                    //    result = (string)jt;
                    //}
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result);
                }

            }
            catch (Exception) {
                throw;
            }
            return result;
        }
    }
}
