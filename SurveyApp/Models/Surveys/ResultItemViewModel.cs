namespace SurveyApp.Models.Surveys
{
    public class ResultItemViewModel
    {
        public long questionId { get; set; }
        public string Content { get; set; }
        public List<AnswerItemViewModel> Answers { get; set; }
    }
}
