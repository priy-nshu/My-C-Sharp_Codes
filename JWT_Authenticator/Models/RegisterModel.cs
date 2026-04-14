using System.ComponentModel.DataAnnotations;

namespace JWT_Authenticator.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserRole { get; set; }
        public string preferences { get; set; }
    }
}
