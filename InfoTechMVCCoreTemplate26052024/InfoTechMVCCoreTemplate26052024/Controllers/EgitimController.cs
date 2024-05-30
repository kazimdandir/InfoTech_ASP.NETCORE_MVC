using InfoTechMVCCoreTemplate26052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechMVCCoreTemplate26052024.Controllers
{
    public class EgitimController : Controller
    {
        public Ogrenci Ogrenci { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Apply(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                Repository.OgrenciEkle(ogr);

                if (ogr.Katilim.HasValue && ogr.Katilim.Value)
                {
                    return Json(new { success = true, message = "Eğitime başvurduğunuz için teşekkür ederiz 🙌 " + ogr.Eposta + " üzerinden tarafınıza dönüş sağlanacaktır 😊" });
                }
                else
                {
                    return Json(new { success = true, message = "Eğitime başvurmadığınız için üzgünüz 🙄 Tekrar görüşmek dileğiyle... ✌️" });
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = "Formda hata var. Lütfen tekrar kontrol edin.", errors });
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = Repository.ogrenciler.FirstOrDefault(x => x.ID == id);
            return View(item);
        }

        [HttpPost]
        public JsonResult EditUser(int ID, Ogrenci ogr)
        {
            try
            {
                Repository.OgrenciDuzenle(ID, ogr);
                return Json(new { success = true, message = "Düzenleme başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            try
            {
                Repository.OgrenciSil(id);
                return Json(new { success = true, message = "Kayıt silme başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
