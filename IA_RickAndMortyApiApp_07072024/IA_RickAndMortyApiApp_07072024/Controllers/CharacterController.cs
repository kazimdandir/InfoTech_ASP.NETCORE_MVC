using IA_RickAndMortyApiApp_07072024.Models.Character;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace IA_RickAndMortyApiApp_07072024.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index(int page = 1, string searchString = null)
        {
            string apiUrl = $"https://rickandmortyapi.com/api/character?page={page}";

            // Download JSON data from API
            string json = new WebClient().DownloadString(apiUrl);

            // Deserialize JSON to Root object
            Root characterData = JsonConvert.DeserializeObject<Root>(json);

            // Filter characters by search string if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                characterData.results = characterData.results.Where(
                    c => c.name.ToLower().Contains(searchString.ToLower())
                ).ToList();
            }

            // Set ViewBag properties for pagination
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = characterData.info.pages;

            // Pass filtered or original character list to view
            return View(characterData.results);
        }


        public IActionResult Details(int id)
        {
            string json = new WebClient().DownloadString($"https://rickandmortyapi.com/api/character/{id}");

            Result character = JsonConvert.DeserializeObject<Result>(json);

            TempData["Name"] = character.name;

            return View(character);
        }
    }
}
