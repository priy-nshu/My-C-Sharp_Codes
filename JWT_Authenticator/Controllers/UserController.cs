using JWT_Authenticator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires JWT Token
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        // Applying your UserRoles knowledge: Multiple roles allowed
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Manager)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound("User not found");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound("User not found");

            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.MobileNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(new { Message = "User updated." });
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)] // Only Admins can delete users
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound("User not found");

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded) return Ok(new { Message = "User deleted." });
            return BadRequest(result.Errors);
        }
    }
}