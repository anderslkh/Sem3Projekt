namespace DesktopConsumer.Models {

    public class ApiAccount {
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }

        public ApiAccount(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public ApiAccount()
        {
        }
    }
}
