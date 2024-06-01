using InfoTechMVCDBFirst01062024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfoTechMVCDBFirst01062024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        NorthwindContext db = new NorthwindContext();

        public IActionResult Index()
        {      
            return View(db.Categories.ToList());
        }

        public IActionResult Create()
        {
            return View();
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
}
