using Microsoft.EntityFrameworkCore;
using W9_ProgettoSettimanale.Context;
using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _ctx;

        public AuthService(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Users> Login(Users user)
        {

            var u = await _ctx.Users.Include(u => u.Roles).Where(u => u.Name == user.Name && u.Password == user.Password).FirstOrDefaultAsync();

            return u;
        }

        public async Task<Users> Register(Users user)
        {

            var roles = await _ctx.Roles.Where(r => r.Id == 2).FirstOrDefaultAsync();
            user.Roles.Add(roles);
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }


    }
}
