using InfoTechCoreMVCKatalogProje02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace InfoTechCoreMVCKatalogProje02062024.Controllers
{
    public class KategoriController : Controller
    {
        MVCKatalogDBContext db = new MVCKatalogDBContext();

        public IActionResult Index()
        {
            var list = db.Kategoris.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                db.Kategoris.Add(kat);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(kat);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("BadRequest");
            }

            Kategori kat = db.Kategoris.Where(x => x.KategoriId == id).FirstOrDefault();

            if (kat == null)
            {
                return BadRequest("BadRequest");
            }

            return View(kat);
        }

        [HttpPost]
        public IActionResult Edit(Kategori kat)
        {
            if(ModelState.IsValid)
            {
                //Kategori kat1 = db.Kategoris.Where(k=>k.KategoriId == kat.KategoriId).First();
                //kat1.KategoriAdi = kat.KategoriAdi;
                //kat1.KategoriAciklama = kat.KategoriAciklama;
                //db.SaveChanges();

                db.Entry(kat).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(kat);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("BadRequest");
            }

            Kategori kat = db.Kategoris.Where(x => x.KategoriId == id).FirstOrDefault();

            if (kat == null)
            {
                return BadRequest("BadRequest");
            }

            return View(kat);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("BadRequest");
            }

            Kategori kat = db.Kategoris.Where(x => x.KategoriId == id).FirstOrDefault();

            db.Kategoris.Remove(kat);
            db.SaveChanges();

            if (kat == null)
            {
                return BadRequest("BadRequest");
            }

            return RedirectToAction("Index");
        }
    }
}
