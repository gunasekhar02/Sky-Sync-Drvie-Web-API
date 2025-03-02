using System.ComponentModel.DataAnnotations;

namespace Sky_Sync_Drvie_Web_API.Models
{
    public class RequestClasses
    {
        public class SignupRequestDto
        {
            public string firstName { get; set; }
            public string lastName { get; set; }

            [Required(ErrorMessage = "Email is required")] // Makes Email mandatory
            public string email { get; set; }
            public string password { get; set; }
        }

        public class LoginRequestDto
        {
            [Required(ErrorMessage = "Email is required")] // Makes Email mandatory
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
