using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models.Users;

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
        public IActionResult SubmitRegistration([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }
            return Redirect("/Auth/Login");
        }
       

    }
}
