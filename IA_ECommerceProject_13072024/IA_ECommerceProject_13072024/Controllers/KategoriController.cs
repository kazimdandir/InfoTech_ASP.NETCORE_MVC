using IA_ECommerceProject_13072024.Models.Context;
using IA_ECommerceProject_13072024.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IA_ECommerceProject_13072024.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ETicaretContext db;

        public KategoriController(ETicaretContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Kategoris.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {

            db.Kategoris.Add(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
