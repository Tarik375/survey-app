using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models.Surveys;

public class TakeSurveyQuestionViewModel
{
    public long QuestionId { get; set; }
    
    public string Question { get; set; }
    
    [Required(ErrorMessage = "Answer is required.")]
    public string Answer { get; set; }
}