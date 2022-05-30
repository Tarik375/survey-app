using Microsoft.EntityFrameworkCore;
using SurveyApp.Database.Models;

namespace SurveyApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; } 
    }
}
