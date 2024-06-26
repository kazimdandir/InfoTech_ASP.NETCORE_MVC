using IA_CoreMVC_MySite_22062024.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        private readonly ProjeContext db;

        public SiteController(ProjeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.BlogYazilari = db.Hakkimda.OrderByDescending(x => x.YaziTarih).ToList();

            return View(db.Projelers.OrderByDescending(x => x.ProjeTarihi).ToList());
        }
    }
}
