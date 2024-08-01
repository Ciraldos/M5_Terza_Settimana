using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Services
{
    public interface IAuthService
    {
        public Task<Users> Login(Users user);
        public Task<Users> Register(Users user);
    }
}
