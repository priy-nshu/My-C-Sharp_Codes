using Microsoft.EntityFrameworkCore;

namespace JWT_Authenticator.Models
{
    public class JWT_DBContext :DbContext
    {
        public JWT_DBContext(DbContextOptions<JWT_DBContext> options) : base(options)
        {
        }
    }
}
