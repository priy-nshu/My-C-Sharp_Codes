using IdentityAutheticationWebAPI.Models;
using IdentityAutheticationWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAutheticationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ApplicationDbContext _context;

        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger, ApplicationDbContext context)
        {
            _authService = authService;
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User model)
        {
            try
            {
                if (!ModelState.IsValid) // Validation error
                {
                    return BadRequest(new { Status = "Error", Message = "Invalid Payload" });
                }

                if (model.UserRole == "Admin" || model.UserRole == "Customer") // Only Admin and Customer
                {
                    // Call server method
                    var (status, message) = await _authService.Registration(model, model.UserRole); //Call Server method

                    if (status == 0)
                    {
                        return BadRequest(new { Status = "Error", Message = message });
                    }
                    //  ------------------Redundant as 'model' is object of User --------------------
                    var user = new User
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                        Email = model.Email,
                        MobileNumber = model.MobileNumber,
                        UserRole = model.UserRole
                    };
                    

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    // return CreatedAtAction(nameof(Register), model);
                    return Ok(new { Status = "Success", Message = message });
                }
                else
                {
                    return BadRequest(new { Status = "Error", Message = "Invalid user role" });
                }

            }
            catch (Exception ex) { 
                throw;
            }
        }
    }
}
