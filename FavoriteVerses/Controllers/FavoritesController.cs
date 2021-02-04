using FavoriteVerses.DataContext;
using FavoriteVerses.Services;
using FavoriteVerses.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVerses.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly FavoritesDbContext _context;
        private readonly GetVersesService _service;

        public FavoritesController(GetVersesService service, FavoritesDbContext context)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {
            var favorites = _context.FavoriteVerses.ToList();
            return View(favorites);
        }

        [HttpPost]
        public async Task<bool> Add(SearchViewModel search)
        {
            if (!ModelState.IsValid)
                return false;

            VerseSearch result = await _service.GetVerses(search.StartDate, search.TotalVerses);

            if (result == null)
                throw new Exception("No verses found.");

            if (_context.FavoriteVerses.Where(i => i.Id == search.Id).FirstOrDefault() == null)
            {
                var favorite = _service.GetVerseById(result.Verses, search.Id);
                await _context.AddAsync(favorite);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
