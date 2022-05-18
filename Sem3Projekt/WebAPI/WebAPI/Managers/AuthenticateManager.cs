using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Managers {
    public class AuthenticateManager {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateManager(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration) {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        // Returns 0 if user exists
        // Returns -1 if exception is thrown
        // Returns 1 if succeeded
        public async Task<int> Register(RegisterModel model) {
            IManager<Person, string> _personManager = ManagerFactory.CreatePersonManager();
            Person user = null;
            int succeeded = 0;
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists == null)
                {
                    succeeded = -1;
                    user = new(model.FirstName, model.LastName, model.Username, model.BirthDate, model.Email);
                    // Identity user created here, this is where the password is hashed/salted and stored in the database
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded) {
                        // If identity user is successfully created, we create our "own" user as a Person in the database
                        _personManager.CreateItem(user);
                        await _userManager.AddToRoleAsync(user, "User");
                        succeeded = 1;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                // If something goes wrong in the process of creating Person in DB, the identity user is deleted from the database
                await _userManager.DeleteAsync(user);
            }
            return succeeded;
        }

        public async Task<string?> Login(Person LoginPerson)
        {
            var user = await _userManager.FindByNameAsync(LoginPerson.UserName);
            // If the inserted password matches the hashed password in the database, enter if statement
            if (user != null && await _userManager.CheckPasswordAsync(user, LoginPerson.Password))
            {
                // Find and assert the associated roles of the user
                var userRoles = await _userManager.GetRolesAsync(user);

                // Adding a list of claims to be added to the JWT, these are used to identify the user
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                // Adding all roles to the same list of claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                // Generating JWT by GetToken() from the list of claims
                var token = GetToken(authClaims);
                string result = token.ToString();
                if (!string.IsNullOrWhiteSpace(result)) {
                    JObject ResultObject = JObject.Parse(result);
                    JToken jt = ResultObject["token"];
                    result = (string)jt;
                    return result;
                }
            }
            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims) {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
