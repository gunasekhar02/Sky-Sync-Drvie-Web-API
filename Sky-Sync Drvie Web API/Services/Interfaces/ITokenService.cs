using Sky_Sync_Drvie_Web_API.Models;

namespace Sky_Sync_Drvie_Web_API.Services
{
    public interface ITokenService
    {
       string GenerateJwtToken(User user);

    }
}
