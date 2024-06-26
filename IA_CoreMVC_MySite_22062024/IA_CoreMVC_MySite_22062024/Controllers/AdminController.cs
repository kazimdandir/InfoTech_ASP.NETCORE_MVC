using IA_CoreMVC_MySite_22062024.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                                                 .ToList()
            };

            return View(model);
        }
    }

    public class AdminDashboardViewModel
    {
        public int BlogCount { get; set; }
        public int ProjectCount { get; set; }
        public int MessageCount { get; set; }
        public List<int> MonthlyBlogCounts { get; set; }
        public List<int> MonthlyProjectCounts { get; set; }
    }
}
