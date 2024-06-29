using Microsoft.AspNetCore.Mvc;

namespace IA_CoreMVC_AjaxPost_29062024.Controllers
{
    public class ExamController : Controller
    {
        public static string[] sonuclar = new string[11]; 

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sonuc(IFormCollection s)
        {
            for (int i = 0; i <= 10; i++)
            {
                sonuclar[i] = s[$"s{i}"];
            }
            return View();
        }
    }
}
