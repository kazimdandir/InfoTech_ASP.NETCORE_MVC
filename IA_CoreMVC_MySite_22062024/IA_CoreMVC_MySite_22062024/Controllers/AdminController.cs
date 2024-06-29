using IA_CoreMVC_MySite_22062024.Models.Context;
using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ProjeContext _context;

        public AdminController(ProjeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //claim listten veri okuma
            var claims = User.Claims;
            var ad = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value; // claimlistten isim çeker
            var soyadi = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value; 

            ViewBag.Ad = ad;
            ViewBag.Soyadi = soyadi;

            //httpcontext
            ViewBag.Ad1 = HttpContext.User.Claims.FirstOrDefault(c => c.Type != ClaimTypes.Name)?.Value;

            var model = new AdminDashboardViewModel
            {
                BlogCount = _context.Hakkimda.Count(),
                ProjectCount = _context.Projelers.Count(),
                MessageCount = _context.Iletisims.Count(),
                MonthlyBlogCounts = Enumerable.Range(1, 12)
                                              .Select(month => _context.Hakkimda.Count(h => h.YaziTarih.Month == month))
                                              .ToList(),
                MonthlyProjectCounts = Enumerable.Range(1, 12)
                                                 .Select(month => _context.Projelers.Count(p => p.ProjeTarihi.Month == month))
                                                 .ToList(),
                MonthlyMessageCounts = Enumerable.Range(1, 12)
                                                 .Select(month => _context.Iletisims.Count(m => m.Tarih.Month == month))
                                                 .ToList()
            };

            ViewBag.UnreadMessagesCount = _context.Iletisims.Count();

            return View(model);
        }

        public IActionResult Messages()
        {
            var messages = _context.Iletisims.ToList();
            return View(messages);
        }
    }

    public class AdminDashboardViewModel
    {
        public int BlogCount { get; set; }
        public int ProjectCount { get; set; }
        public int MessageCount { get; set; }
        public List<int> MonthlyBlogCounts { get; set; }
        public List<int> MonthlyProjectCounts { get; set; }
        public List<int> MonthlyMessageCounts { get; set; }
    }

}
