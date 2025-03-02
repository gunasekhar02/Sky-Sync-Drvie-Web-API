using Sky_Sync_Drvie_Web_API.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using static Sky_Sync_Drvie_Web_API.Models.RequestClasses;

namespace Sky_Sync_Drvie_Web_API.Services
{
    public class UserService:IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(SignupRequestDto signupUser)
        {
            var user = new User
            {
                Email = signupUser.email,
                FirstName = signupUser.firstName,
                LastName = signupUser.lastName,
                Password = BCrypt.Net.BCrypt.HashPassword(signupUser.password) // Hash password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> AuthenticateUser(LoginRequestDto loginUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.password, user.Password))
                return null;

            return user;
        }
    }
}
