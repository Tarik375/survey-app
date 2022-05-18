namespace SurveyApp.Database.Models
{
    public class Survey

    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }


    }
}
