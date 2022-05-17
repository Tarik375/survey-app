using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Database.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Username { get; set; }

        [Required]
        [MaxLength(320)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PasswordHash { get; set; }
    }
}
