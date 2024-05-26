using InfoTechMVCCoreTemplate26052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechMVCCoreTemplate26052024.Controllers
{
    public class EgitimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                Repository.OgrenciEkle(ogr);
                return View("Tesekkurler", ogr);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListeKatilanlar()
        {
            var liste = Repository.Ogrenciler.Where(x => x.Katilim == true);
            return View(liste);
        }

        public IActionResult ListeKatilmayanlar()
        {
            var liste = Repository.Ogrenciler.Where(x => x.Katilim == false);
            return View(liste);
        }
    }
}
