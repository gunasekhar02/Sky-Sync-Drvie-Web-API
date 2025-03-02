using System.ComponentModel.DataAnnotations;

namespace Sky_Sync_Drvie_Web_API.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
