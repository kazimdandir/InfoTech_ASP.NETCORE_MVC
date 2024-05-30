using InfoTechCoreMVCQuiz26052024.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTechCoreMVCQuiz26052024.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserClaim userClaim = new UserClaim
            {
                UserID = 6,
                UserName = "John ",
                UserLastName = "Doe"
            };

            ViewBag.UserClaim = userClaim;

            return View();
        }
    }
}
