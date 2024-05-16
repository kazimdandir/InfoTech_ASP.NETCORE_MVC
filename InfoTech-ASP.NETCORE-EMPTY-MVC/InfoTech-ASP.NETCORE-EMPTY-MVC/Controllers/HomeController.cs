using InfoTech_ASP.NETCORE_EMPTY_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTech_ASP.NETCORE_EMPTY_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Yazi()
        {
            return View();
        }

        public IActionResult Veri()
        {
            Employee e = new Employee();
            e.FirstName = "Ali";
            e.LastName = "Veli";

            return View(e);
        }
    }
}
