namespace SurveyApp.Models.Surveys
{
    public class SurveyResultViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public long surveyId { get; set; }
        public List<ResultItemViewModel> Results { get; set; }
    }
}
