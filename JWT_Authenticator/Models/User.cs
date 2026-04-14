using System.ComponentModel.DataAnnotations;

namespace JWT_Authenticator.Models
{
    public class User
    {
        [Key]
        public int UsertId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string UserRole { get; set; }
    }
}
