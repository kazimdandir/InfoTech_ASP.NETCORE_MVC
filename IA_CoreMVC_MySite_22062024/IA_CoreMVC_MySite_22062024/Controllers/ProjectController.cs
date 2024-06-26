using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjeContext db;

        public ProjectController(ProjeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Projelers.ToList());
        }

        public IActionResult Create(Projeler projeler)
        {
            projeler.ProjeTarihi = DateTime.Now;
            return View(projeler);
        }

        [HttpPost]
        public IActionResult Create(Projeler projeler, IFormFile ProjeFoto)
        {
            if (ModelState.IsValid)
            {
                if (ProjeFoto != null)
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ProjeFoto.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        projeler.ProjeFoto = imageName;
                        ProjeFoto.CopyTo(stream);
                    }
                }

                db.Projelers.Add(projeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projeler);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Projeler projeler = db.Set<Projeler>().FirstOrDefault(p => p.ProjeID == id);

            if (projeler == null)
            {
                return NotFound();
            }

            return View(projeler);
        }

        [HttpPost]
        public IActionResult Edit(Projeler projeler, IFormFile? ProjeFoto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ProjeFoto != null)
                    {
                        // Benzersiz bir dosya adı oluşturulur
                        string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ProjeFoto.FileName);
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

                        // Dosya akışını using bloğu içinde açarak dosyanın kapatılması sağlar
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            projeler.ProjeFoto = imageName;
                            ProjeFoto.CopyTo(stream);
                        }
                    }

                    db.Entry(projeler).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (projeler == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(projeler);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Projeler projeler = db.Set<Projeler>().FirstOrDefault(p => p.ProjeID == id);

            if (projeler == null)
            {
                return NotFound();
            }

            return View(projeler);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Projeler projeler = db.Projelers.Where(h => h.ProjeID == id).FirstOrDefault();

            db.Projelers.Remove(projeler);
            db.SaveChanges();

            if (projeler == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
