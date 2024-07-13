using IA_ECommerceProject_13072024.Models.Context;
using IA_ECommerceProject_13072024.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IA_ECommerceProject_13072024.Controllers
{
    public class UrunController : Controller
    {
        private readonly ETicaretContext db;

        public UrunController(ETicaretContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Uruns.Include(x => x.Kategori).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.RefKategoriID = new SelectList(db.Kategoris, "KategoriID", "KategoriAdi");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Urun urun, IFormFile UrunFoto)
        {
            if (urun != null)
            {
                if (UrunFoto != null)
                {
                    string imageName = UrunFoto.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/urun/{imageName}");
                    var stream = new FileStream(path, FileMode.Create);
                    urun.UrunFoto = imageName;
                    UrunFoto.CopyTo(stream);
                }

                db.Uruns.Add(urun);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.RefKategoriID = new SelectList(db.Kategoris, "KategoriID", "KategoriAdi", urun.RefKategoriID);

            return View(urun);
        }
    }
}
