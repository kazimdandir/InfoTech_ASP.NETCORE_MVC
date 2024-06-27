using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    public class MessageController : Controller
    {
        private readonly ProjeContext db;

        public MessageController(ProjeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Iletisims.ToList());
        }

        public async Task<IActionResult> Create(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Iletisims.Add(iletisim);
                db.SaveChanges();
                Thread.Sleep(2500);
                return RedirectToAction("Index", "Site"); // Mesaj gönderildikten sonra ana sayfaya yönlendirelim
            }
            return View(iletisim);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Iletisim iletisim = db.Iletisims.FirstOrDefault(i => i.IletisimID == id);

            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        public IActionResult Delete (int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Iletisim iletisim = db.Iletisims.Where(h => h.IletisimID == id).FirstOrDefault();

            db.Iletisims.Remove(iletisim);
            db.SaveChanges();

            if (iletisim == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
