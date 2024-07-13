using IA_RickAndMortyApiApp_07072024.Models.Episode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace IA_RickAndMortyApiApp_07072024.Controllers
{
    public class EpisodeController : Controller
    {
        public IActionResult Index()
        {
            string json = new WebClient().DownloadString("https://rickandmortyapi.com/api/episode");

            Root episodeData = JsonConvert.DeserializeObject<Root>(json);

            return View(episodeData.results);
        }

        public IActionResult Details(int id)
        {
            string json = new WebClient().DownloadString($"https://rickandmortyapi.com/api/episode/{id}");

            Result episode = JsonConvert.DeserializeObject<Result>(json);

            TempData["Name"] = episode.name;

            return View(episode);
        }
    }
}
