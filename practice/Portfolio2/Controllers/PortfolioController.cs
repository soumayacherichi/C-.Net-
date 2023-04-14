using Microsoft.AspNetCore.Mvc;
namespace PORTFOLIO.Controllers;
public class PortfolioController : Controller
{
    //Routes
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("index");
    }
    [HttpGet("project")]
    public ViewResult Project()
    {
        return View("project");
    }
    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("contact");
    }

}