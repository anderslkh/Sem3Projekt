using DesktopConsumer.Models;
using DesktopConsumer.Security;
using DesktopConsumer.Service;
using System.Collections.Specialized;
using System.Configuration;

namespace DesktopConsumer.Controller
{
    public class TokenController
    {
        private readonly NameValueCollection _tokenAdminValues;

        public TokenController()
        {
            _tokenAdminValues = ConfigurationManager.AppSettings;
        }
        
        public async Task<string> GetToken(TokenState currentState) {
            string foundToken = null;
            if (currentState == TokenState.Valid) {
                foundToken = GetTokenExisting();
            }
            if (currentState == TokenState.Invalid) {
                foundToken = await GetTokenNew();
            }
            return foundToken;
        }

        private string GetTokenExisting() {
            string foundToken = null;
            if (_tokenAdminValues.HasKeys()) {
                foundToken = _tokenAdminValues.Get("JwtToken");
            }
            return foundToken;
        }
        private async Task<string> GetTokenNew() {
            string foundToken;

            // Get AccountData
            ApiAccount accountData = GetApiAccountCredentials();

            // Access a new Token from service (Web API)
            LoginService loginService = new LoginService();
            foundToken = await loginService.Login(accountData);

            if (foundToken != null) {
                AddUpdateAppSettings("JwtToken", foundToken);
            }
            return foundToken;
        }
        private ApiAccount GetApiAccountCredentials() {
            ApiAccount foundData = new ApiAccount();

            if (_tokenAdminValues.HasKeys()) {
                foundData.Password = _tokenAdminValues.Get("Password");
                foundData.GrantType = _tokenAdminValues.Get("GrantType");
                foundData.Username = _tokenAdminValues.Get("Username");
            }


            return foundData;
        }

        void AddUpdateAppSettings(string key, string value) {
            try {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null) {
                    settings.Add(key, value);
                } else {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException) {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
