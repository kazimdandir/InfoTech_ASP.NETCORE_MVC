using InfoTechCoreMVCKutuphane02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCKutuphane02062024.Controllers
{
    public class KitapController : Controller
    {

        KutuphaneContext db = new KutuphaneContext();

        public IActionResult List()
        {
            var list = db.Kitaps
                .Include(k => k.YazarnoNavigation)
                .Include(k => k.TurnoNavigation)
                .Where(k => k.TurnoNavigation.Silindimi == false && k.YazarnoNavigation.Silindimi == false && k.Silindimi == false)
                .OrderBy(k => k.Kitapno)
                .ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Yazarlar = db.Yazars
                .Where(y => y.Silindimi == false)
                .ToList();

            ViewBag.Turler = db.Turs
                .Where(t => t.Silindimi == false)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitap k)
        {
            if (ModelState.IsValid)
            {
                k.Silindimi = false;
                db.Kitaps.Add(k);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Yazarlar = db.Yazars
                .Where(y => y.Silindimi == false)
                .ToList();

            ViewBag.Turler = db.Turs
                .Where(t => t.Silindimi == false)
                .ToList();

            return View(k);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            var kitap = db.Kitaps.Find(id);

            if (kitap == null)
            {
                return NotFound();
            }

            ViewBag.Yazarlar = db.Yazars
                .Where(y => y.Silindimi == false)
                .ToList();

            ViewBag.Turler = db.Turs
                .Where(t => t.Silindimi == false)
                .ToList();

            return View(kitap);
        }

        [HttpPost]
        public IActionResult Edit(Kitap k)
        {
            if (ModelState.IsValid)
            {
                db.Entry(k).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Yazarlar = db.Yazars
                .Where(y => y.Silindimi == false)
                .ToList();

            ViewBag.Turler = db.Turs
                .Where(t => t.Silindimi == false)
                .ToList();

            return View(k);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            var kitap = db.Kitaps
                .Include(k => k.YazarnoNavigation)
                .Include(k => k.TurnoNavigation)
                .FirstOrDefault(k => k.Kitapno == id);

            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Kitap k = db.Kitaps
                .Where(x => x.Kitapno == id)
                .FirstOrDefault();

            k.Silindimi = true;

            db.Kitaps.Update(k);
            db.SaveChanges();

            if (k == null)
            {
                return BadRequest("404");
            }

            return RedirectToAction("List");
        }
    }
}
