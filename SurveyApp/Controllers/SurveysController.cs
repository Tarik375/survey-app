using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database;
using SurveyApp.Database.Models;
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
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            long userId = long.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var survey = new Survey()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedDate = DateTime.UtcNow,
                UserId = userId,
            };
            _db.Surveys.Add(survey);
            _db.SaveChanges();

            return Redirect("/Surveys/Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            long userId = long.Parse(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            List<Survey> surveys = _db.Surveys.Where(survey => survey.Id == userId).ToList();
            SurveyIndexViewModel surveyIndex = new SurveyIndexViewModel();
            surveyIndex.Surverys = new List<SurveyItemViewModel>();
            surveys.ForEach(survey =>
            {
                SurveyItemViewModel surveyItem = new SurveyItemViewModel();
                surveyItem.Id = survey.Id;
                surveyItem.Name = survey.Name;
                surveyItem.Description = survey.Description;
                surveyItem.CreatedDate = survey.CreatedDate;
                surveyIndex.Surverys.Add(surveyItem);
            });
            return View(surveyIndex);
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