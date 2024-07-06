using IA_APIHaberlesme_06072024.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace IA_APIHaberlesme_06072024.Controllers
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
            //Nwetonsoft.Json paketi eklendi

            string json = new WebClient().DownloadString("http://localhost:5171/api/users"); // api'deki verileri okur

            //önce servisi(api uygulamasını ayağa kaldırmalıyız)
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json); //jsonda okunan veriyi listeye dönüştür

            return View(users);
            //return Json(users);
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
