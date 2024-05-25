using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCfULL18052024.Controllers
{
    public class SampleController : Controller
    {
        //viewBag, ViewData, TempData
        public IActionResult Index() //sample/index
        {
            ViewBag.Tarih = DateTime.Now.ToLongDateString();
            ViewBag.koleksiyon = new string[] { "Bu", "bir", "dizidir" };

            ViewData["Saat"] = DateTime.Now.ToLongTimeString();

            TempData["Fiyat"] = 2500; // sample/index'ten bir kez alıyor daha sonra farklı bir viewta kullanabiliyoruz tek bir seferlik --> home/privacy

            return View();
        }
    }
}
