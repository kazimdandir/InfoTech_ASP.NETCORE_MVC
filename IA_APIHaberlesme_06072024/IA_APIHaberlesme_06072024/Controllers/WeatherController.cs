using IA_APIHaberlesme_06072024.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace IA_APIHaberlesme_06072024.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            string hava = new WebClient().DownloadString("http://api.weatherapi.com/v1/current.json?key=987cc86185ce45d1b3a105745240607%20&q=Istanbul&aqi=no");

            Root havaDrm = JsonConvert.DeserializeObject<Root>(hava);

            

            return View(havaDrm);
        }

        
        public IActionResult UcSehir()
        {
            string istanbul = new WebClient().DownloadString("http://api.weatherapi.com/v1/current.json?key=987cc86185ce45d1b3a105745240607%20&q=Istanbul&aqi=no");

            string ankara = new WebClient().DownloadString("http://api.weatherapi.com/v1/current.json?key=987cc86185ce45d1b3a105745240607%20&q=ankara&aqi=no");

            string bursa = new WebClient().DownloadString("http://api.weatherapi.com/v1/current.json?key=987cc86185ce45d1b3a105745240607%20&q=bursa&aqi=no");

            Root istanbulHavaDrm = JsonConvert.DeserializeObject<Root>(istanbul);
            Root ankaraHavaDrm = JsonConvert.DeserializeObject<Root>(ankara);
            Root bursaHavaDrm = JsonConvert.DeserializeObject<Root>(bursa);

            var havaData = new List<Root> { istanbulHavaDrm, ankaraHavaDrm , bursaHavaDrm};

            return View(havaData);
        }

        
    }
}
