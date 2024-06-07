using InfoTechCoreMVCKutuphane02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InfoTechCoreMVCKutuphane02062024.Controllers
{
    public class YazarController : Controller
    {
        KutuphaneContext db = new KutuphaneContext();

        public IActionResult List()
        {
            var list = db.Yazars
                .Where(x => x.Silindimi == false)
                .OrderBy(x => x.Yazarno)
                .ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Yazar y)
        {
            if (ModelState.IsValid)
            {
                y.Silindimi = false;
                db.Yazars.Add(y);
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(y);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Yazar y = db.Yazars
                .Where(x => x.Yazarno == id)
                .FirstOrDefault();

            if (y == null)
            {
                return BadRequest("404");
            }

            return View(y);
        }

        [HttpPost]
        public IActionResult Edit(Yazar y)
        {
            if (ModelState.IsValid)
            {
                y.Silindimi = false;
                db.Entry(y).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(y);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Yazar y = db.Yazars
                .Where(x => x.Yazarno == id)
                .FirstOrDefault();

            if (y == null)
            {
                return BadRequest("404");
            }

            return View(y);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Yazar y = db.Yazars
                .Where(x => x.Yazarno == id)
                .FirstOrDefault();

            y.Silindimi = true;

            db.Yazars.Update(y);
            db.SaveChanges();

            if (y == null)
            {
                return BadRequest("404");
            }

            return RedirectToAction("List");
        }
    }
}
