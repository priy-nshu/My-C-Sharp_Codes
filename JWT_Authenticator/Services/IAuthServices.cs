using JWT_Authenticator.Models;

namespace JWT_Authenticator.Services
{
    public interface IAuthServices
    {
        Task<(int, string)> Registration(RegisterModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}
