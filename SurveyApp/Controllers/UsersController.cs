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
    }
}
