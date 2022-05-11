using System.Collections.Specialized;
using System.Configuration;
using DesktopConsumer.Models;
using DesktopConsumer.Service;
using DesktopConsumer.Servicelayer;

namespace DesktopConsumer.Security {
    public class TokenManager {

        private readonly NameValueCollection _tokenAdminValues;          // To hold AppSettings

        public TokenManager() {
            _tokenAdminValues = ConfigurationManager.AppSettings;
        }

        // Relay for calling appropriate method according to TokenState
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

        // Get existing JWT token from configuration (AppSettings)
        private string GetTokenExisting() {
            string foundToken = null;
            if (_tokenAdminValues.HasKeys()) {
                foundToken = _tokenAdminValues.Get("JwtToken");
            }
            return foundToken;
        }

        // Manage retrieval and persistense of new token value
        private async Task<string> GetTokenNew() {
            string foundToken;

            // Get AccountData
            ApiAccount accountData = GetApiAccountCredentials();

            // Access a new Token from service (Web API)
            TokenServiceAccess tokenServiceAccess = new TokenServiceAccess();
            foundToken = await tokenServiceAccess.GetNewToken(accountData);

            if (foundToken != null) {
                AddUpdateAppSettings("JwtToken", foundToken);
            }

            return foundToken;
        }

        // Get application credentials from configuration (AppSettings)
        private ApiAccount GetApiAccountCredentials() {
            ApiAccount foundData = new ApiAccount();

            if (_tokenAdminValues.HasKeys()) {
                foundData.Password = _tokenAdminValues.Get("Password");
                foundData.GrantType = _tokenAdminValues.Get("GrantType");
                foundData.Username = _tokenAdminValues.Get("Username");
            }


            return foundData;
        }

        // Get the process (project) assembly name (applied as application username) 
        private string GetApplicationAssemblyName() {
            string assemblyName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            return assemblyName;
        }

        // Store new token value for use in successive request to the service
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

