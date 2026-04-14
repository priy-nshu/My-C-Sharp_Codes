using JWT_Authenticator.Models;
using JWT_Authenticator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthenticationController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Status = "Error", Message = "Invalid Payload" });

            if (model.UserRole == UserRoles.Admin || model.UserRole == UserRoles.Manager || model.UserRole == UserRoles.User)
            {
                var (status, message) = await _authService.Registration(model, model.UserRole);

                if (status == 0)
                    return BadRequest(new { Status = "Error", Message = message });

                return Ok(new { Status = "Success", Message = message });
            }
            else
            {
                return BadRequest(new { Status = "Error", Message = "Invalid user role" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Status = "Error", Message = "Invalid Payload" });

            var (status, message) = await _authService.Login(model);

            if (status == 0)
                return BadRequest(new { Status = "Error ", Message = message });

            return Ok(new { Status = "Success", Token = message });
        }
    }
}
