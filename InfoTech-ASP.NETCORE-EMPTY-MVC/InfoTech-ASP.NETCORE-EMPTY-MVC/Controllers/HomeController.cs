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

        List<Employee> employees = new List<Employee>();

        public IActionResult Veriler()
        {
            Employee e = new Employee();
            e.FirstName = "Ali";
            e.LastName = "Veli";
            employees.Add(e);

            Employee e1 = new Employee();
            e1.FirstName = "Ali";
            e1.LastName = "Veli";
            employees.Add(e1);

            Employee e2 = new Employee();
            e2.FirstName = "Ali";
            e2.LastName = "Veli";
            employees.Add(e2);

            return View(employees);
        }

        public IActionResult LayoutTest()
        {
            return View();
        }
    }
}
