using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authenticator.Models
{
    public class JWT_DBContext : IdentityDbContext<IdentityUser>
    {
        public JWT_DBContext(DbContextOptions<JWT_DBContext> options) : base(options)
        {
        }
    }
}
