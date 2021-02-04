using FavoriteVerses.DataContext;
using FavoriteVerses.Models;
using FavoriteVerses.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FavoriteVerses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetVersesService _service;

        public HomeController(ILogger<HomeController> logger, GetVersesService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel() { TotalVerses = 5 } );
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel search)
        {
            VerseSearch result = null;
            if (ModelState.IsValid)
            {
                result = await _service.GetVerses(search.StartDate, search.TotalVerses);
            }

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
