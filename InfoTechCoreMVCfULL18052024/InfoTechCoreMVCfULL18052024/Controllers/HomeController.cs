using InfoTechCoreMVCfULL18052024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace InfoTechCoreMVCfULL18052024.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "Admin" & sifre == "1234")
            {
                return RedirectToAction("Hosgeldiniz", "Home"); //actionresult'a gider
                //return View("Hosgeldiniz", kullaniciAdi); //view'e gider
            }
            else
            {
                return View();
            }
        }

        public IActionResult Hosgeldiniz()
        {
            return View();
        }


        public IActionResult BirdenFazlModel()
        {
            var book = new List<Book>
            {
                new Book {BookName = "Kitap1"},
                new Book {BookName = "Kitap2"},
                new Book {BookName = "Kitap3"}
            };

            var customer = new List<Customer>
            {
                new Customer { Ad = "Ali"},
                new Customer { Ad = "Veli"},
                new Customer { Ad = "Can"},
            };

            var customerBook = new CustomerBookVM
            {
                Books = book,
                Customers = customer
            };

            return View(customerBook);
        }

        public IActionResult CustomerEkle()
        {
            return View();
        }

        public IActionResult CustomerListele()
        {
            var veriler = new List<Customer>()
            {
                new Customer {Id = 1, Ad = "Ali", Soyad = "Veli", Yas = 22, Cinsiyet = "Erkek"},
                new Customer {Id = 1, Ad = "Ali", Soyad = "Veli", Yas = 22, Cinsiyet = "Erkek"},
                new Customer {Id = 1, Ad = "Ali", Soyad = "Veli", Yas = 22, Cinsiyet = "Erkek"},
                new Customer {Id = 1, Ad = "Ali", Soyad = "Veli", Yas = 22, Cinsiyet = "Erkek"},
                new Customer {Id = 1, Ad = "Ali", Soyad = "Veli", Yas = 22, Cinsiyet = "Erkek"}
            };

            return View(veriler);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
