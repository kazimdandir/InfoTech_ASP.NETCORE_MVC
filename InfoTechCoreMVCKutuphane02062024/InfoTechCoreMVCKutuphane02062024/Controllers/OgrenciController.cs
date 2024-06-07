using InfoTechCoreMVCKutuphane02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCKutuphane02062024.Controllers
{
    public class OgrenciController : Controller
    {
        KutuphaneContext db = new KutuphaneContext();

        public IActionResult List()
        {
            var list = db.Ogrencis
                .Where(x => x.Silindimi == false)
                .OrderBy(x => x.Ogrno)
                .ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogrenci o)
        {
            if (ModelState.IsValid)
            {
                o.Silindimi = false;
                db.Ogrencis.Add(o);
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(o);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Ogrenci o = db.Ogrencis
                .Where(x => x.Ogrno == id)
                .FirstOrDefault();

            if (o == null)
            {
                return BadRequest("404");
            }

            return View(o);
        }

        [HttpPost]
        public IActionResult Edit(Ogrenci o)
        {
            if (ModelState.IsValid)
            {
                o.Silindimi = false;
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(o);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Ogrenci o = db.Ogrencis
                .Where(x => x.Ogrno == id)
                .FirstOrDefault();

            if (o == null)
            {
                return BadRequest("404");
            }

            return View(o);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Ogrenci o = db.Ogrencis
                .Where(x => x.Ogrno == id)
                .FirstOrDefault();

            o.Silindimi = true;

            db.Ogrencis.Update(o);
            db.SaveChanges();

            if (o == null)
            {
                return BadRequest("404");
            }

            return RedirectToAction("List");
        }
    }
}
