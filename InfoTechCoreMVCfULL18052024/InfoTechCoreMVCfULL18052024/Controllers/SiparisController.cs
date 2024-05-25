using InfoTechCoreMVCfULL18052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCfULL18052024.Controllers
{
    public class SiparisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunSat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunSat(IFormCollection veri)
        {
            TempData["SatilanUrunID"] = Convert.ToInt32(veri["urunID"]);    
            TempData["SatilanUrunAd"] = veri["urunAdi"].ToString();    
            TempData["SatilanUrunFiyat"] = veri["urunFiyati"].ToString();    

            return RedirectToAction("StokAzalt", "Urun");
        }

        public IActionResult UrunSatModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunSatModel(Product p)
        {
            Product pr = new Product();
            pr.Id = p.Id;
            pr.Name = p.Name;
            pr.Price = p.Price;

            //return View("sonuc", pr); //farklı bir view a model gönderme

            return RedirectToAction("urunmodelal", pr); //farklı bir action a model gönderme
        }

        public IActionResult urunmodelal(Product p)
        {
            return View(p);
        }
    }
}
