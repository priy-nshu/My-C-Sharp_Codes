using JWT_Authenticator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Applying your UserRoles knowledge: Only Admins can manage roles
    [Authorize(Roles = UserRoles.Admin)]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound("Role not found");
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("Role name is required");
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded) return Ok(new { Message = $"Role {roleName} created." });
            return BadRequest(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] string newRoleName)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded) return Ok(new { Message = "Role updated." });
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded) return Ok(new { Message = "Role deleted." });
            return BadRequest(result.Errors);
        }
    }
}