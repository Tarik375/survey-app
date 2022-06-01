namespace SurveyApp.Database.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
