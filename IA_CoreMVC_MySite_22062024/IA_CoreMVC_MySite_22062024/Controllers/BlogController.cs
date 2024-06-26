using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hakkimda hakkimda, IFormFile YaziFoto)
        {
            if (ModelState.IsValid)
            {
                //Dosya ekleme

                if (YaziFoto != null)
                {
                    string imageName = YaziFoto.Name;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    var stream = new FileStream(path, FileMode.Create);
                    hakkimda.YaziFoto = imageName;
                    YaziFoto.CopyTo(stream);
                }

                db.Hakkimda.Add(hakkimda);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(hakkimda);
        }
    }
}
