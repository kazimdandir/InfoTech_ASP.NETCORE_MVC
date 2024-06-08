using InfoTechCoreMVCCodeFirst08062024.Models;
using InfoTechCoreMVCCodeFirst08062024.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfoTechCoreMVCCodeFirst08062024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        OrnekContext db = new OrnekContext();

        public IActionResult Index()
        {
            return View(db.Kategori.ToList());
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
