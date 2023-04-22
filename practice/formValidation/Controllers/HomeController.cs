using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using firstmvc.Models;

namespace firstmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Pet> AllPets = new List<Pet>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet ("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet ("Success")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [HttpPost("create")]
    public IActionResult Create(Pet NewPet)
    {
        Console.WriteLine($"{NewPet.Name} \n{NewPet.Age}\n {NewPet.IsFriendly}\n {NewPet.Color}");
        if (ModelState.IsValid)
        {
            AllPets.Add(NewPet);
            return View("Success",AllPets);
        }
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
