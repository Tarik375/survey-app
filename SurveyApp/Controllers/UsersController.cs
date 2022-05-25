using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Database;
using SurveyApp.Database.Models;
using SurveyApp.Models.Users;

namespace SurveyApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }
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

            List<User> users = _db.Users
                                        .Where(x => x.Username.ToLower() == model.Username.ToLower() || x.Email.ToLower() == model.Email.ToLower())
                                        .ToList();

            if (users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "This email is already taken.");
            }
            if (users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
            {
                ModelState.AddModelError("Username", "This username is already taken.");
            }

            if (!ModelState.IsValid)
            {

                return View("Register", model);
            }

            var user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return Redirect("/Auth/Login");
        }


    }
}



