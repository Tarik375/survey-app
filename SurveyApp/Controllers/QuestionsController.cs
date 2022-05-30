using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database;
using SurveyApp.Database.Models;
using SurveyApp.Models.Questions;

namespace SurveyApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly AppDbContext _db;

        public QuestionsController(AppDbContext db)
        {
            _db = db; 
        }
        
        
        [HttpPost]
        public IActionResult Create([FromForm] CreateQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var question = new Question()
            {
                Content = model.Content,
                SurveyId = model.SurveyId
            };

            _db.Questions.Add(question);
            _db.SaveChanges();

            return RedirectToAction("Details", "Surveys", new { id = model.SurveyId }); 
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}