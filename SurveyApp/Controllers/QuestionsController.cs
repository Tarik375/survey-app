using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database;
using SurveyApp.Database.Models;
using SurveyApp.Models.Questions;

namespace SurveyApp.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly AppDbContext _db;

        public QuestionsController(AppDbContext db)
        {
            _db = db; 
        }
        
        [HttpGet]
        public IActionResult Create(long SurveyId)
        {
            CreateQuestionViewModel model = new CreateQuestionViewModel();
            model.SurveyId = SurveyId;
            return View(model);
            
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
        
        [HttpGet]
        public IActionResult Delete(long? Id)
        {
            var question = _db.Questions.FirstOrDefault(x => x.Id == Id);
            _db.Questions.Remove(question);
            _db.SaveChanges();
            return RedirectToAction("Details", "Survey", new { id = question.SurveyId });

        }
    }
    
}