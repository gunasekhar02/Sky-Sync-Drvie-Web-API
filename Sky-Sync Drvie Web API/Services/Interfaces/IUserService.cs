using Sky_Sync_Drvie_Web_API.Models;
using static Sky_Sync_Drvie_Web_API.Models.RequestClasses;

namespace Sky_Sync_Drvie_Web_API.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(SignupRequestDto user);
        Task<User> AuthenticateUser(LoginRequestDto loginUser);
    }
}
