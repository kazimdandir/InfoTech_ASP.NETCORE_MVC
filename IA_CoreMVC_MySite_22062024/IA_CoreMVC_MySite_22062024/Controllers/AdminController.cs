using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_MySite_22062024.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
