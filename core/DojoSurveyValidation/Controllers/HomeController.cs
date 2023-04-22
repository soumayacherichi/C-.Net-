using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidation.Models;

namespace DojoSurveyValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost("process")]
    public IActionResult Process(string Username, string Location, string Language, string Comment)
    {
        if(ModelState.IsValid)
        {
        ViewBag.Username = Username;
        ViewBag.Location= Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        return View("Display");
        }
        return View("Index");
    }
    [HttpGet("Display")]
    public ViewResult Display()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
