using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab5WebApplication.Models;

namespace Lab5WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
