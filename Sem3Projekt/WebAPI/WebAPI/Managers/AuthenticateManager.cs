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
        // Returns 1 if succeded
        public async Task<int> Register(RegisterModel model) {
            IManager<Person, string> _personManager = ManagerFactory.CreatePersonManager();
            Person user = null;
            int succeded = 0;
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists == null)
                {
                    succeded = -1;
                    user = new(model.FirstName, model.LastName, model.Username, model.BirthDate, model.Email);
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded) {
                        _personManager.CreateItem(user);
                        await _userManager.AddToRoleAsync(user, "User");
                        succeded = 1;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                await _userManager.DeleteAsync(user);
            }
            return succeded;
        }
    }
}
