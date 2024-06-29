using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_Session_29062024.Controllers
{
    public class OturumController : Controller
    {
        const string kullaniciAdi = "ad";
        const string kullaniciMaili = "mail";
        const string kullaniciYasi = "yas";

        public IActionResult Index()
        {
            //session oluşturma

            HttpContext.Session.SetString("ad", "Infotech");
            HttpContext.Session.SetInt32(kullaniciYasi, 18);
            HttpContext.Session.SetString(kullaniciMaili, "info@info.com");

            return View();
        }

        public IActionResult Oturum()
        {
            ViewBag.kAdi = HttpContext.Session.GetString(kullaniciAdi);
            ViewBag.kMail = HttpContext.Session.GetString("mail");
            ViewBag.kYasi = HttpContext.Session.GetInt32(kullaniciYasi);

            ViewBag.Id = HttpContext.Session.Id;

            return View();
        }
    }
}
