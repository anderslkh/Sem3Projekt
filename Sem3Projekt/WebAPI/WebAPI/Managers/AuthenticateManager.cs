using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    }
}
