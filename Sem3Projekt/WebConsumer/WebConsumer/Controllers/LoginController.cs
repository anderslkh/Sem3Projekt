using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebConsumer.Models;
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
        public async Task<IActionResult> Login(string username, string password) {
            string result = "";
            LoginService loginService = new LoginService();
            try {
                Person loginPerson = new Person(username, password);
                result = await loginService.Login(username, password);

                if (!string.IsNullOrWhiteSpace(result)) {
                    JObject ResultObject = JObject.Parse(result);
                    JToken jt = ResultObject["token"];
                    string TokenString = (string)jt;

                    JwtSecurityToken jwtToken = new JwtSecurityToken(TokenString);

                    var claimsIdentity = new ClaimsIdentity(jwtToken.Claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }

            return View();
        }

        [HttpGet]
        [Route("Register")]
        public async Task<IActionResult> Register() {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(string firstname, string lastname, string username, string password, string email, DateTime birthdate) {
            LoginService loginService = new LoginService();
            RegisterModel registerPerson = new RegisterModel { FirstName = firstname, LastName = lastname, Username = username, BirthDate = birthdate, Email = email, Password = password };
            await loginService.Register(registerPerson);
            return View("../Home/Index");
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> LogOut() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
