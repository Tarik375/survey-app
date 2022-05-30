using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models.Questions;

public class CreateQuestionViewModel
{
    [Required(ErrorMessage = "Question is required.")]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Question must be between 3 and 1000 characters long.")]
    
    public string? Content;

    public long SurveyId; 
}