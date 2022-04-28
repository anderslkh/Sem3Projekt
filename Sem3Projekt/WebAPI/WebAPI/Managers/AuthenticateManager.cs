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

        public async Task<bool> Register(RegisterModel model) {
            IManager<Person, string> _personManager = ManagerFactory.CreatePersonManager();
            Person user = null;
            bool succeded = false;
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists == null) {
                    user = new() {
                        Email = model.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = model.Username,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate,
                        NickName = model.Username
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    
                    if (result.Succeeded) {
                        succeded = _personManager.CreateItem(user);
                        await _userManager.AddToRoleAsync(user, "User");
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
