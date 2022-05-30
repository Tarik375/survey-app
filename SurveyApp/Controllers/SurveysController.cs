using Microsoft.AspNetCore.Mvc;
using SurveyApp.Database;
using SurveyApp.Models.Surveys;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SurveyApp.Database.Models;




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
            ViewData["Id"] = Id;
            return View();
            
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditSurveyViewModel model, [FromQuery(Name = "Id")] int? Id)
        {
            ViewData["Id"] = Id;

            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var survey =  _db.Surveys.FirstOrDefault(s => s.Name == model.Name ||  s.Description == model.Description);

            

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, survey.Name),
                new Claim(ClaimTypes.NameIdentifier, survey.Id.ToString()),
                new Claim(ClaimTypes.Name, survey.Description)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);


            List<Survey> surveys = _db.Surveys.Where(survey => survey.Id == Id).ToList();
            SurveyEditViewModel surveyIndex = new SurveyEditViewModel();
            surveyIndex.Surverys = new List<EditSurveyViewModel>();
            surveys.ForEach(survey =>
            {
                EditSurveyViewModel surveyItem = new EditSurveyViewModel();
                surveyItem.Id = survey.Id;
                surveyItem.Name = survey.Name;
                surveyItem.Description = survey.Description;
                surveyIndex.Surverys.Add(surveyItem);
            });
            return View(surveyIndex);
        }
    }
}


  