using InfoTechCoreMVCfULL18052024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfoTechCoreMVCfULL18052024.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            if(kullaniciAdi == "Admin" & sifre == "1234")
            {
                return RedirectToAction("Hosgeldiniz", "Home"); //actionresult'a gider
                //return View("Hosgeldiniz", kullaniciAdi); //view'e gider
            }
            else
            {
                return View();
            }       
        }

        public IActionResult Hosgeldiniz()
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
