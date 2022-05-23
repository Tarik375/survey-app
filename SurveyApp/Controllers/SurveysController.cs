using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models.Surveys;

namespace SurveyApp.Controllers
{
    public class SurveysController : Controller
    {
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
    }
}
