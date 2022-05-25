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




/*var model1 = await _db.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower()
              || x.Username.ToLower() == model.Username.ToLower());
            

            if (!(model1 == null) ||  !BCrypt.Net.BCrypt.Verify(model.Email, model1.Email))
            {
              //if(_db.Users.Where(x => x.Email == model.Email))
                ModelState.AddModelError(string.Empty, "This email is already taken.");
              
            }
            if (!(model1 == null) || !BCrypt.Net.BCrypt.Verify(model.Username, model1.Username))
            {
                //if(_db.Users.Select(x => x.Email == model.Email))
                ModelState.AddModelError(string.Empty, "This username is already taken.");

            }
            if (!(model1 == null) || ( !BCrypt.Net.BCrypt.Verify(model.Email, model1.Email) && !BCrypt.Net.BCrypt.Verify(model.Username, model1.Username)))
            {
                //if(_db.Users.Where(x => x.Email == model.Email && x.Username == model.Username))
                ModelState.AddModelError(string.Empty, "This email and username is already taken.");
                 
            }
                        
            return View(model1);*/

/* var user = new User()
 {

     Email = model.Email,   
     Username = model.Username,
     PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)


 };

 _db.Users.Add(user);
 _db.SaveChanges();*/
// return Redirect("/Auth/Login");

/*else if(ModelState.IsValid)
            {
                if (!UsersController.Exists(RegisterViewModel.Username))
                {
                    if (!user.EmailExists(RegisterViewModel.Email))
                    {
                        _db.Add(
                            new User
                            {
                                Created = DateTime.Now,
                                Email = RegisterViewModel.Email,
                                Password = RegisterViewModel.Password,
                                Username = RegisterViewModel.Username
                            });

                        _db.SaveChanges();
                        TempData["RegistrationDetails"] = RegisterViewModel;

                        return RedirectToAction("Confirm");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "This email is already taken.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This username is already taken.");
                }
            }

            return View(RegisterViewModel);
        }*/