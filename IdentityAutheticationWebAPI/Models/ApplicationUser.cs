using Microsoft.AspNetCore.Identity;
using System.Data.Common;

namespace IdentityAutheticationWebAPI.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string UserPreference { get; set; }
    }
}
