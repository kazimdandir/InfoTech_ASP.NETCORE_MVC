using InfoTechCoreMVCfULL18052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCfULL18052024.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //HtmpHelpers MVC5'te zaten vardı
        //TagHelpers core ile geldi

        //HtmlHelpers ile oluşturulan form
        public IActionResult HtmlHelpers() => View(); //get tarafı

        [HttpPost]
        public IActionResult HtmlHelpers(User user)
        {
            return View("TagHelpers"); 
        }

        //TagHelpers ile oluşturulan form
        public IActionResult TagHelpers() => View(); 

        [HttpPost]
        public IActionResult TagHelpers(User user)
        {
            return View("HtmlHelpers"); 
        }
    }
}
