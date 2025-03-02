using System.ComponentModel.DataAnnotations;

namespace Sky_Sync_Drvie_Web_API.Models
{
    public class RequestClasses
    {
        public class SignupRequestDto
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }

            [Required(ErrorMessage = "Email is required")] // Makes Email mandatory
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

        public class LoginRequestDto
        {
            [Required(ErrorMessage = "Email is required")] // Makes Email mandatory
            public string? Email { get; set; }
            public string? Password { get; set; }
        }
    }
}
