namespace SurveyApp.Models.Surveys;

public class TakeSurveyViewModel
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public List<TakeSurveyQuestionViewModel> Questions { get; set; }

}