using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltReview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeltReview.Controllers;

public class HomeController : Controller

{
	private MyContext _context;
    private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,MyContext context)
        {
        _logger = logger;
        _context = context;

        }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(User newReg)
    {
        if(ModelState.IsValid){
            if(_context.Users.Any(u=>u.Email == newReg.Email))
            {
                ModelState.AddModelError("Email","Email Already exist!!");
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newReg.Password = Hasher.HashPassword(newReg, newReg.Password);
            _context.Add(newReg);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId",newReg.UserId);

            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    [HttpPost]
    public IActionResult Login(UseRouting newLog)
    {
        if (ModelState.IsValid){
            var UserInDb= _context.Users.FirstOrDefault(u=>u.Email==newLog.LoginEmail);
            if (UserInDb==null){
                ModelState.AddModelError("LoginEmail","Invalid Email");
                return View("Index");
            }
            else{
            var hasher=new PasswordHasher<UseRouting>();
            var result= hasher.VerifyHashedPassword(newLog, UserInDb.Password ,newLog.LoginPassword);
            if(result==0){
                ModelState.AddModelError("LoginPassword","Wrong Password");
                return View("Index");
            } 
            HttpContext.Session.SetInt32("UserId",UserInDb.UserId);
            HttpContext.Session.SetString("UserName",UserInDb.FirstName);

            return RedirectToAction("Dashboard");
            }
            
        } else {

        return View("Index");
        }
    }
    public IActionResult Logout ()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    [SessionChek]
    public IActionResult Dashboard()
    {
        ViewBag.AllProd = _context.Products.ToList();
        return View();
    }

    [SessionChek]
    [HttpGet("/addproduct")]
    public IActionResult AddProduct()
    {
        return View();

    }
    public IActionResult CreateProduct(Product newprod)
    {
        if (ModelState.IsValid)
        {
        newprod.UserId=(int) HttpContext.Session.GetInt32("UserId");
        _context.Add(newprod);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
        }
        return View("AddProduct");

    }
    // ****************PRODUCT*************
    // DElETE
    [HttpGet("/product/delete/{ProductId}")]
    public IActionResult DeleteProd (int ProductId)
    {
        Product tobedel=_context.Products.FirstOrDefault(p=>p.ProductId==ProductId);
        _context.Products.Remove(tobedel);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }
    // EDIT
        [HttpGet("/product/edit/{ProductId}")]
    public IActionResult EditProd (int ProductId)
    {
        Product tobeup=_context.Products.FirstOrDefault(p=>p.ProductId==ProductId);

        return View(tobeup);
    }
    public IActionResult UpdateProduct (int ProductId, Product uppro)
    {
        Product tobeup=_context.Products.FirstOrDefault(p=>p.ProductId==ProductId);
        if (ModelState.IsValid){
        tobeup.Name=uppro.Name;
        tobeup.Price=uppro.Price;
        tobeup.Quantity=uppro.Quantity;
        tobeup.Description=uppro.Description;
        tobeup.UpdatedAt=DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
        }
        return View("EditProd" ,tobeup);

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class SessionChekAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        int ? UserId =context.HttpContext.Session.GetInt32("UserId");
        if (UserId ==null)
        {
            context.Result = new RedirectToActionResult("Index","Home",null);
        }
    }
}