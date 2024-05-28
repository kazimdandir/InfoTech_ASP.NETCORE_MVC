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

        public IActionResult TumListe()
        {
            var liste = Repository.ogrenciler;
            return View(liste);
        }

        public IActionResult ListeKatilanlar()
        {
            var liste = Repository.ogrenciler.Where(x => x.Katilim == true);
            return View(liste);
        } 

        public IActionResult ListeKatilmayanlar()
        {
            var liste = Repository.ogrenciler.Where(x => x.Katilim == false);
            return View(liste);
        }

        public IActionResult Delete(string Ad)
        {
            Repository.OgrenciSil(Ad);
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
