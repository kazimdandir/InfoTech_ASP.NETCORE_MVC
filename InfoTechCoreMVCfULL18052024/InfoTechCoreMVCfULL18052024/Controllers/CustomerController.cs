using InfoTechCoreMVCfULL18052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCfULL18052024.Controllers
{
    public class CustomerController : Controller
    {
        static List<Customer> musteriler = new List<Customer>();

        //[HttpGet] //Default
        public IActionResult Index()
        {
            //LINQ Sorguları
            return View(musteriler.Where(y => y.Yas > 20).OrderBy(x => x.Ad).ToList());
        }

        public IActionResult Yeni()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Yeni(IFormCollection f)
        //{
        //    Customer c = new Customer();
        //    c.Id = int.Parse(f["Id"]);
        //    c.Ad = f["Ad"];
        //    c.Soyad = f["Soyad"];
        //    c.Yas = Convert.ToInt32(f["Yas"]);
        //    c.Cinsiyet = f["Cinsiyet"];
        //    musteriler.Add(c);

        //    return RedirectToAction("Index");
        //}

        //Yukarıdakidekinin alternatif yazımı aşağıdaki gibidir
        [HttpPost]
        public IActionResult Yeni(Customer f)
        {
            musteriler.Add(f);

            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            var musteri = musteriler.Where(x => x.Id == id).First();
            return View(musteri);
        }
    }
}
