using IA_RickAndMortyApiApp_07072024.Models.Episode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace IA_RickAndMortyApiApp_07072024.Controllers
{
    public class EpisodeController : Controller
    {
        private const int PageSize = 10;

        public IActionResult Index(int page = 1, string searchString = null)
        {
            string apiUrl = $"https://rickandmortyapi.com/api/episode?page={page}";

            // Download JSON data from API
            string json = new WebClient().DownloadString(apiUrl);

            // Deserialize JSON to Root object
            Root episodeData = JsonConvert.DeserializeObject<Root>(json);

            // Filter episodes by search string if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                episodeData.results = episodeData.results.Where(
                    e => e.name.ToLower().Contains(searchString.ToLower())
                ).ToList();
            }

            // Set ViewBag properties for pagination
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = episodeData.info.pages;
            ViewBag.SearchString = searchString; // Ekledik

            // Pass filtered or original episode list to view
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
