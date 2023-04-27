using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefDishes.Controllers;

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
        List<Chef> Allchefs = _context.Chefs.Include(c => c.ChefDishes).ToList();
        // _context.SaveChanges();
        ViewBag.Allchefs = Allchefs;
        return View();
    }

    // ADD CHEF
    public IActionResult AddChef() {
        return View();
    }


    [HttpPost("/chef/add")]
    public IActionResult CreateChef(Chef newChef) {
       if (DateTime.Compare(newChef.DateOfBirth, DateTime.Now) > 0)
            {
                ModelState.AddModelError("DateOfBirth", "Date of Birth must be in past");
            }   
        if (ModelState.IsValid && newChef.IsAtLeast18YearsOld()) {
            ModelState.AddModelError("DateOfBirth", "Chef must be greater than 18 year");
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else
        {
            return View("AddChef");
        }
    }

    // DISHES
    public IActionResult Diches() {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Owner).ToList();
        _context.SaveChanges();
        ViewBag.AllDishes = AllDishes;
        return View();
    }

    // ADD DISH
    public IActionResult AddDish() {
        List<Chef> Allchefs = _context.Chefs.ToList();
        _context.SaveChanges();
        ViewBag.Allchefs = Allchefs;
        return View();
    }

    [HttpPost("/dish/add")]
    public IActionResult CreateDish(Dish newDish) {
       
        if(ModelState.IsValid) {
            List<Chef> Allchefs = _context.Chefs.ToList();
            _context.SaveChanges();
           ViewBag.Allchefs = Allchefs;
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Diches");
        } else {
            List<Chef> Allchefs = _context.Chefs.ToList();
            _context.SaveChanges();
            ViewBag.Allchefs = Allchefs;
           return View("AddDish");
        }
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
