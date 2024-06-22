using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [AllowAnonymous] //her yerden açık
    public class SecurityController : Controller
    {
        //ProjeContext db = new ProjeContext();

        private readonly ProjeContext db;

        public SecurityController(ProjeContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string KullaniciAdi, string Parola)
        {
            Kullanici girisYapanKullanici = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == KullaniciAdi && x.Parola == Parola);

            if (girisYapanKullanici != null)
            {
                //claim yapısı ile authentication 

                var claim = new List<Claim>()
                {
                    new Claim("ID", girisYapanKullanici.KullaniciID.ToString()),
                    new Claim(ClaimTypes.Name, girisYapanKullanici.Adi),
                    new Claim(ClaimTypes.Surname, girisYapanKullanici.Soyadi),
                    new Claim("KullaniciAdi", girisYapanKullanici.KullaniciAdi),
                    new Claim(ClaimTypes.Role, girisYapanKullanici.Rolu)
                };

                var userIdentity = new ClaimsIdentity(claim, "Security");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                HttpContext.SignInAsync(principal); // şifreli bir cookie oluşturup geçerli yanıta ekler

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }            
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();

            return View("Login");
        }

        public IActionResult ErisimEngellendi()
        {
            return View();
        }
    }
}
