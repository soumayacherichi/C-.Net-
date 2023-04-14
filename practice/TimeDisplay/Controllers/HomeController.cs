using Microsoft.AspNetCore.Mvc;
namespace TIMEDISPLAY.Controllers;
public class HomeController : Controller
{
public IActionResult Index()
{
    DateTime currentTime = DateTime.Now;
    string formattedTime = currentTime.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
    ViewData["CurrentTime"] = formattedTime;
    return View();
}
}