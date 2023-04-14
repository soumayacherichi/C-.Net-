using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;
public class DojoSurveyController : Controller
{
    //routes
    [HttpGet] //Type of the request
    [Route("")]//associated route (/)
    public ViewResult Index()
    {
        return View("Index");
    }
    [HttpPost("process")]
    public IActionResult Process(string Username, string location, string language, string comment)
    {
        Console.WriteLine($"Your Name: {Username} \n Location: {location} \n Favorite Language: {language} \n Comment: {comment}");
        if (Username == ""|| location == "" || language == ""|| comment == "")
        {
            ViewBag.Error="Wrong Information";
            return RedirectToAction("Index");
        }
        ViewBag.Username = Username;
        ViewBag.location= location;
        ViewBag.language = language;
        ViewBag.comment = comment;
        return View("result");
    }
    [HttpGet("Result")]
    public ViewResult Result()
    {
        ViewBag.Username = "Alexander";
        ViewBag.FavNumber= 5;
        return View();
    }


}