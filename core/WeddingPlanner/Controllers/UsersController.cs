using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;//Hashing Password


namespace WeddingPlanner.Controllers
{
    public class UsersController : Controller
    {
        private WeddingContext _context;

        public UsersController(WeddingContext context)
        {
            _context = context;
        }

        [HttpPost, Route("/users")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetString("UserName", newUser.FirstName + " " + newUser.LastName);
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard", "Weddings"); 
            }
            return View("Registration");
        }
        
        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost, Route("/login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.users.FirstOrDefault(u=> u.Email == model.Email);
            if(UserFromDB == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            PasswordHasher<LoginViewModel> hasher = new PasswordHasher<LoginViewModel>();
            //  verify Password 
            var  result = hasher.VerifyHashedPassword(model,hashedPassword: UserFromDB.Password, model.Password);
            if(result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            HttpContext.Session.SetInt32("UserId", UserFromDB.UserId);
            return RedirectToAction("Dashboard", "Weddings");        
            }
            return View("Login");
        }

        [HttpGet, Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet, Route("")]
        public IActionResult ShowRegistrationForm()
        {
            return View("Registration");
        }
    }
}