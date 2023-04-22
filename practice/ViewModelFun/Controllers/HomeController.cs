using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<User> AllUsers = new List<User>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("Users")]
    public IActionResult Success()
    {
        return View();
    }
    [HttpPost("create")]
    public IActionResult Create(User NewUser)
    {
       
        if(ModelState.IsValid)
        {
            System.Console.WriteLine($"Name : {NewUser.FirstName}\n Last name : {NewUser.LastName}\n Number : {NewUser.Number}");
            AllUsers.Add(NewUser);
            return View("Users", AllUsers);
        }
        return View("Index");
    }
    [HttpPost("user")]
    public IActionResult newUser(string FirstName, int LastName)
    {
        ViewBag.FirstName = FirstName;
        ViewBag.LastName = LastName;
        return View("user");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
