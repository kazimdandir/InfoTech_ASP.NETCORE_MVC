using InfoTechCoreMVCKutuphane02062024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCKutuphane02062024.Controllers
{
    public class TurController : Controller
    {
        KutuphaneContext db = new KutuphaneContext();

        public IActionResult List()
        {
            var list = db.Turs
                .Where(x => x.Silindimi == false)
                .OrderBy(x => x.Turno)
                .ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tur t)
        {
            if (ModelState.IsValid)
            {
                t.Silindimi = false;
                db.Turs.Add(t);
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(t);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("404");
            }

            Tur t = db.Turs
                .Where(x => x.Turno == id)
                .FirstOrDefault();

            t.Silindimi = true;

            db.Turs.Update(t);
            db.SaveChanges();

            if (t == null)
            {
                return BadRequest("404");
            }

            return RedirectToAction("List");
        }
    }
}
