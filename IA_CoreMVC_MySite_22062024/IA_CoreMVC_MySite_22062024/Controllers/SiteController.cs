using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
