using JWT_Authenticator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authenticator.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<(int, string)> Registration(RegisterModel model, string role)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return (0, "User Already exists");

            IdentityUser user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var createUserResult = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please Check user details and try again");

            // Handle Roles (AspNetRoles table)
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            // Assign Roles to User (AspNetUserRoles table)
            await _userManager.AddToRoleAsync(user, UserRoles.User); // Give everyone 'User' role
            if (role != UserRoles.User)
                await _userManager.AddToRoleAsync(user, role);   // Assign the specific role

            return (1, "User Created successfully");
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            // ONLY use Identity's UserManager to find the user
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return (0, "Invalid email or password");

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid email or password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id), // Use Identity's built-in string ID
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = GenerateToken(authClaims);
            return (1, token);
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
