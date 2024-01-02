using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SaleWebMVC.Models.ViewModels;

namespace SaleWebMVC.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult About() {
        ViewData["title"]    = "Sales Web MVC App From C# Course";
        ViewData["subTitle"] = "Testing subTitle";

        return View();
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}