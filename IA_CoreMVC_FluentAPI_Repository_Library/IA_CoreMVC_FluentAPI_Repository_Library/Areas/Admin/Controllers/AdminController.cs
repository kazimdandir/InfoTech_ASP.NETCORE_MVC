using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
