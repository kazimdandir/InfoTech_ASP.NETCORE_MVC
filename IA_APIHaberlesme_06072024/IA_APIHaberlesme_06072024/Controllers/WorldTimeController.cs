using IA_APIHaberlesme_06072024.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace IA_APIHaberlesme_06072024.Controllers
{
    public class WorldTimeController : Controller
    {
        public IActionResult Index()
        {
            string json = new WebClient().DownloadString("https://worldtimeapi.org/api/ip"); 

            Time time = JsonConvert.DeserializeObject<Time>(json);

            return View(time);
        }
    }
}
