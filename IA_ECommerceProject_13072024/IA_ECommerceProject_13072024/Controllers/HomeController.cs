using IA_ECommerceProject_13072024.Models;
using IA_ECommerceProject_13072024.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IA_ECommerceProject_13072024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ETicaretContext db;

        public HomeController(ILogger<HomeController> logger, ETicaretContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.KategoriListesi = db.Kategoris.ToList();

            ViewBag.SonUrunler = db.Uruns
                .OrderByDescending(x => x.UrunID)
                .Skip(0)
                .Take(12)
                .ToList();

            return View();
        }

        public IActionResult Kategori(int? id)
        {
            ViewBag.KategoriListesi = db.Kategoris.ToList();
            ViewBag.Kategori = db.Kategoris.FirstOrDefault(x => x.KategoriID == id);

            return View(db.Uruns.Where(x => x.RefKategoriID == id).OrderBy(x => x.UrunAdi).ToList());
        }

        public IActionResult Urun(int? id)
        {
            ViewBag.KategoriListesi = db.Kategoris.ToList();

            return View(db.Uruns.Find(id));
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
