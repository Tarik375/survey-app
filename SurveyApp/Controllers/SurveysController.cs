using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using SurveyApp.Database;
>>>>>>> master
using SurveyApp.Models.Surveys;

namespace SurveyApp.Controllers
{
    public class SurveysController : Controller
    {
        private readonly AppDbContext _db;

        public SurveysController(AppDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitSurvey([FromForm] CreateSurveyViewModel model)
        {   
            if(!ModelState.IsValid)
            {
                return View("Create", model);
            }
            return Redirect("/Surveys/Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SurveryIndexViewModel());
        }
    }
}
