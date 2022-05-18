using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitRegistration()
        {
            return Redirect("/Auth/Login");
        }
    }
}
