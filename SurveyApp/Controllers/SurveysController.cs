using Microsoft.AspNetCore.Mvc;

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
        public IActionResult SubmitSurvey()
        {
            return Redirect("/Surveys/Index");
        }
    }
}
