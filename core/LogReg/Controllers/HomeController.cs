using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogRegLecture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LogRegLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("/users/create")]
    public IActionResult CreateUser(User NewUser)
    {
        if(ModelState.IsValid)
        {
            // Email exist ?
            if(_context.Users.Any(u=>u.Email == NewUser.Email))
            {
                // YES
                ModelState.AddModelError("Email", "Email already taken, hope by you");
                return View("Index");
            }
            else
            {
                // NO
                // Hash Password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                System.Console.WriteLine(NewUser.Password);
                // Add
                _context.Add(NewUser);
                // Save
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId",NewUser.UserId);
                return RedirectToAction("Success");
            }
        }
        return View("Index");
    }
    [HttpPost("/users/login")]
    public IActionResult Login (LoginUser loginUser)
    {
        if(ModelState.IsValid)
        {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.Users.FirstOrDefault(u=> u.Email == loginUser.LoginEmail);
            if(UserFromDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //  verify Password 
            var  result = hasher.VerifyHashedPassword(loginUser,hashedPassword: UserFromDB.Password, loginUser.LoginPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", UserFromDB.UserId);
            return RedirectToAction("Success");
        }
        // 
        return View("Index");
    }

    public IActionResult Success()
    {
        if(HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
