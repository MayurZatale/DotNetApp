using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Index(IFormCollection form)
    {
        var email=form["em"].ToString();
        var pass=form["pass"].ToString();
        if(email=="admin@gmail.com"&&pass=="admin123"){
            return RedirectToAction("Index","User");
        }
        return RedirectToAction("Index","Home");
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
