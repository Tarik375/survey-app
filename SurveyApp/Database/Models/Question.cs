namespace SurveyApp.Database.Models
{
    public class Question
    {

        public long Id { get; set; }

        public string? Content { get; set; }

        public long SurveyId { get; set; }

        public Survey? Survey { get; set; }
        public List<Question> Questions { get; set; }
    }
}
