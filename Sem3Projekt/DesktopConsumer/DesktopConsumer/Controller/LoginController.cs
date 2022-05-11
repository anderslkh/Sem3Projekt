using DesktopConsumer.Models;
using DesktopConsumer.Security;
using DesktopConsumer.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DesktopConsumer.Controller
{
    public class LoginController
    {
        public async void Login(string username, string password)
        {
            string result = "";
            LoginService loginService = new LoginService();
            TokenManager tokenManager = new TokenManager();
            try
            {
                ApiAccount loginPerson = new ApiAccount(username, password);
                result = await loginService.Login(loginPerson);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    JObject ResultObject = JObject.Parse(result);
                    JToken jt = ResultObject["token"];
                    string TokenString = (string)jt;

                    JwtSecurityToken jwtToken = new JwtSecurityToken(TokenString);

                    var claimsIdentity = new ClaimsIdentity(jwtToken.Claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(new Claim("access_token", jwtToken.RawData));



                    new ClaimsPrincipal(claimsIdentity);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
