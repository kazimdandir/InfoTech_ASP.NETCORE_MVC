using Microsoft.AspNetCore.Mvc;

namespace InfoTechMVCCoreAreas08062024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
