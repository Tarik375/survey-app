using SurveyApp.Models.Questions;

namespace SurveyApp.Models.Surveys
{
    public class SurveyDetailsViewmodel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<QuestionItemViewModel> Questions { get; set; }
    }
}
