using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebConsumer.Models;
using WebConsumer.Models.LoginModels;
using WebConsumer.Service;

namespace WebConsumer.Controllers {
    public class LoginController : Controller {

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> Login(string username, string password)
        {
            string result = "";
            LoginService loginService = new LoginService();
            try
            {
                Person loginPerson = new Person(username, password);
                result = await loginService.Login(username, password);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    JObject ResultObject = JObject.Parse(result);
                    JToken jt = ResultObject["token"];
                    string TokenString = (string)jt;

                    JwtSecurityToken jwtToken = new JwtSecurityToken(TokenString);

                    var claimsIdentity = new ClaimsIdentity(jwtToken.Claims, "Login");
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return View();
        }
    }
}
