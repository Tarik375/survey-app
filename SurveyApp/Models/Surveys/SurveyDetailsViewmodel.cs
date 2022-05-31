namespace SurveyApp.Models.Surveys
{
    public class SurveyDetailsViewmodel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Questions.QuestionItemViewModel> Questions { get; set; }
    }
}
