using IA_CoreMVC_AjaxPost_29062024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IA_CoreMVC_AjaxPost_29062024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(ExamController.sonuclar);
        }

        public IActionResult FormTasarimi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormTasarimi(Kisiler kisiler)
        {
            TempData["Ad"] = kisiler.Ad;
            TempData["Soyad"] = kisiler.Soyad;
            TempData["Tel"] = kisiler.Telefon;
            TempData["EPosta"] = kisiler.EPosta;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
