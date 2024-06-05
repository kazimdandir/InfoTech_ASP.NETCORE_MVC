using InfoTechCoreMVCKutuphane02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCKutuphane02062024.Controllers
{
    public class IslemController : Controller
    {
        KutuphaneContext db = new KutuphaneContext();

        public IActionResult List()
        {
            var list = db.Islems
                .Include(x => x.KitapnoNavigation)
                .Include(x => x.OgrnoNavigation)
                .Where(x => x.KitapnoNavigation.Silindimi == false && x.OgrnoNavigation.Silindimi == false && x.Teslim == false && x.Vtarih == null)
                .ToList();

            return View(list);
        }

        public IActionResult DeliveredList()
        {
            var list = db.Islems
                .Include(x => x.KitapnoNavigation)
                .Include(x => x.OgrnoNavigation)
                .Where(x => x.KitapnoNavigation.Silindimi == false && x.OgrnoNavigation.Silindimi == false && x.Teslim == true || x.Vtarih != null)
                .ToList();
            
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Kitaplar = db.Kitaps.Where(x => x.Silindimi == false).ToList();
            ViewBag.Ogrenciler = db.Ogrencis.Where(x => x.Silindimi == false).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Islem i)
        {
           if (ModelState.IsValid)
           {
                i.Teslim = false;
                db.Islems.Add(i);
                db.SaveChanges();
                return RedirectToAction("List");
           }

            ViewBag.Kitaplar = db.Kitaps.Where(x => x.Silindimi == false).ToList();
            ViewBag.Ogrenciler = db.Ogrencis.Where(x => x.Silindimi == false).ToList();

            return View(i);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var islem = db.Islems
                .Include(x => x.KitapnoNavigation)
                .Include(x => x.OgrnoNavigation)
                .FirstOrDefault(x => x.Islemno == id);

            if (islem == null)
            {
                return NotFound();
            }

            return View(islem);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Islem i = db.Islems.Where(x => x.Kitapno == id).FirstOrDefault();

            i.Teslim = true;
            i.Vtarih = DateTime.Now;

            db.Islems.Update(i);
            db.SaveChanges();

            if (i == null)
            {
                return BadRequest();
            }

            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var islem = db.Islems.Find(id);
            if (islem == null)
            {
                return NotFound();
            }

            ViewBag.Kitaplar = db.Kitaps.Where(x => x.Silindimi == false).ToList();
            ViewBag.Ogrenciler = db.Ogrencis.Where(x => x.Silindimi == false).ToList();
            return View(islem);
        }

        [HttpPost]
        public IActionResult Edit(Islem i)
        {
            if (ModelState.IsValid)
            {
                i.Teslim = false;
                db.Entry(i).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Kitaplar = db.Kitaps.Where(x => x.Silindimi == false).ToList();
            ViewBag.Ogrenciler = db.Ogrencis.Where(x => x.Silindimi == false).ToList();

            return View(i);
        }

    }
}
