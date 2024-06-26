using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly ProjeContext db;

        public BlogController(ProjeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Hakkimda.ToList());
        }

        public IActionResult Create(Hakkimda hakkimda)
        {
            hakkimda.YaziTarih = DateTime.Now;
            return View(hakkimda);
        }

        [HttpPost]
        public IActionResult Create(Hakkimda hakkimda, IFormFile YaziFoto)
        {
            if (ModelState.IsValid)
            {
                if (YaziFoto != null)
                {
                    // Benzersiz bir dosya adı oluşturulur
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(YaziFoto.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

                    // Dosya akışını using bloğu içinde açarak dosyanın kapatılması sağlar
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        hakkimda.YaziFoto = imageName;
                        YaziFoto.CopyTo(stream);
                    }
                }

                db.Hakkimda.Add(hakkimda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimda);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Hakkimda hakkimda = db.Set<Hakkimda>().FirstOrDefault(h => h.ID == id);

            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        [HttpPost]
        public IActionResult Edit(Hakkimda hakkimda, IFormFile? YaziFoto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (YaziFoto != null)
                    {
                        // Benzersiz bir dosya adı oluşturulur
                        string imageName = Guid.NewGuid().ToString() + Path.GetExtension(YaziFoto.FileName);
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

                        // Dosya akışını using bloğu içinde açarak dosyanın kapatılması sağlar
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            hakkimda.YaziFoto = imageName;
                            YaziFoto.CopyTo(stream);
                        }
                    }

                    db.Entry(hakkimda).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (hakkimda == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(hakkimda);
        }


        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Hakkimda hakkimda = db.Set<Hakkimda>().FirstOrDefault(h => h.ID == id);

            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest(); 
            }

            Hakkimda hakkimda = db.Hakkimda.Where(h => h.ID == id).FirstOrDefault();

            db.Hakkimda.Remove(hakkimda);
            db.SaveChanges();

            if (hakkimda == null)
            {
                return BadRequest(); 
            }

            return RedirectToAction("Index");
        }
    }
}
