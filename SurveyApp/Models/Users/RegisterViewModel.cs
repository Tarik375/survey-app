using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models.Users
{
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression("^[A-Za-z0-9_-]{3,16}$", ErrorMessage = "Username can contain only letters, numbers, underscore and a hypen and must be between 3 and 16 characters long.")]
        public string? Username{ get; set; }
       
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format is incorrect.")]
        public string? Email{get; set;  }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,50}$", ErrorMessage = "Password must contain minimum of eight characters, at least one letter and one number.")]
        [DataType(DataType.Password)]
        public string? Password{ get; set;   }

        [Required(ErrorMessage = "Password Configrmation is required.")]
        [Compare("Password", ErrorMessage = "Password and Password Confirmation must match.")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm{  get; set;  }



    }
}
