using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or email is required.")]
        public string? UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]

        public string? Password { get; set; }
    }
}
