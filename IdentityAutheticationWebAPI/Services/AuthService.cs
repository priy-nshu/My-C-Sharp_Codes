using IdentityAutheticationWebAPI.Migrations;
using IdentityAutheticationWebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace IdentityAutheticationWebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                    IConfiguration configuration,ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.context = context;
        }

        public async Task<(int,string)> Registration(User model,string role)
        {
            var userExists =await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return (0, "User Already exist");
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(), //Globally Unique ID
                UserPreference = "Default"

            };

            var createUserResult =await userManager.CreateAsync(user,model.Password);
            if (!createUserResult.Succeeded)
            {
                return (0, "User creation failed! Please Check user details and try again");
            }
            if (!await roleManager.RoleExistsAsync(role))// Add role to ASP.Roles table if it doesnot exit
                await roleManager.CreateAsync(new IdentityRole(role));
            if (!await roleManager.RoleExistsAsync(UserRoles.User)) //Add User to the Roles table if doesn't exit
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if(!await roleManager.RoleExistsAsync(UserRoles.User))  //Assign User Role to the user
                await userManager.AddToRoleAsync(user,UserRoles.User);
            await userManager.AddToRoleAsync(user, role);   //Assign the specified role to the user
            return (1, "User Created successfully");

        }

        public async Task<(int ,string)> Login(LoginModel model)
        {
            return (0, "Not Implemented");
        }
    }
}
