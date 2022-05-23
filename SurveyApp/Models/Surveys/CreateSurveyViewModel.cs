using System.ComponentModel.DataAnnotations;
namespace SurveyApp.Models.Surveys
{
    public class CreateSurveyViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [Range(3, 20, ErrorMessage = "Name must be between 3 and 20 characters long.")]

        public string? Name { get; set; }

        [MaxLength(50, ErrorMessage = "Description can't be longer than 50 characters.")]
        public string? Description { get; set; }
    }
}
