using IdentityAutheticationWebAPI.Models;

namespace IdentityAutheticationWebAPI.Services { 

        public interface IAuthService
        {
            Task<(int, string)> Registration(User model, string role);
            Task<(int, string)> Login(LoginModel model);
        }
    
}
