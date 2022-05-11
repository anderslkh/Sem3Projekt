using DesktopConsumer.Models;
using System.Net.Http.Json;

namespace DesktopConsumer.Servicelayer {
    public class TokenServiceAccess {

        readonly HttpClient _client;
        static readonly string restUrl = "https://localhost:7276/api/authenticate/";  // Insert your own portno

        public TokenServiceAccess() {
            _client = new HttpClient();
        }

        public async Task<string> GetNewToken(ApiAccount accountToUse) {
            string retrievedToken;
            string result = null;

            /* Create elements for HTTP request */
            string useRestUrl = restUrl + "login";
            var uriToken = new Uri(string.Format(useRestUrl));

            // Provide username, password and grant_type for the authentication. Content (body data) are posted in. 
            //HttpContent appAdminLogin = new FormUrlEncodedContent(new[] {
            //    //new KeyValuePair<string, string>("grant_type", accountToUse.GrantType),
            //    new KeyValuePair<string, string>("username", accountToUse.Username),
            //    new KeyValuePair<string, string>("password", accountToUse.Password)
            //});
            

            var response = await _client.PostAsJsonAsync(uriToken, accountToUse);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
