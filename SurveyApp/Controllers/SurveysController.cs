using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database;
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

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var survey = _db.Surveys.FirstOrDefault(x => x.Id == Id);
            EditSurveyViewModel model = new EditSurveyViewModel();
            model.Id = survey.Id;
            model.Name = survey.Name;
            model.Description = survey.Description;
            return View(model);
            
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditSurveyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var survey =  _db.Surveys.FirstOrDefault(x => x.Id == model.Id );
            survey.Name = model.Name;
            survey.Description = model.Description;
            await _db.SaveChangesAsync();
            return Redirect("/Surveys/Index");
        }
    }
}