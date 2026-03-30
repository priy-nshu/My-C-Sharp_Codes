using System.ComponentModel.DataAnnotations;

namespace IdentityAutheticationWebAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }
    }
}
