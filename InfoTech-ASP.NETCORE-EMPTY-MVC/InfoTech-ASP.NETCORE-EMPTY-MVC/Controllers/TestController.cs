using Microsoft.AspNetCore.Mvc;

namespace InfoTech_ASP.NETCORE_EMPTY_MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
