using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;

namespace PasswordGenerator.Controllers;

public class PasscodeController : Controller
{
    private readonly ILogger<PasscodeController> _logger;

    public PasscodeController(ILogger<PasscodeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Index()
    {
        int count = GetPasscodeCount();

        ViewBag.PasscodeNumber = count + 1;

        string passcode = GeneratePasscode();

        SavePasscode(passcode);

        ViewBag.Passcode = passcode;

        return View();
    }

    private string GeneratePasscode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var random = new Random();

        return new string(Enumerable.Repeat(chars, 14)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private int GetPasscodeCount()
    {
        int count = 0;

        if (HttpContext.Session.GetInt32("PasscodeCount") != null)
        {
            count = (int)HttpContext.Session.GetInt32("PasscodeCount");
        }

        return count;
    }

    private void SavePasscode(string passcode)
    {
        int count = GetPasscodeCount() + 1;

        HttpContext.Session.SetInt32("PasscodeCount", count);

        HttpContext.Session.SetString($"Passcode{count}", passcode);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
