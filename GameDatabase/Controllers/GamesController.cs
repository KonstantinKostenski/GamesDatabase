using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using Microsoft.AspNetCore.Authorization;
using GameDatabase.Models;

namespace GameDatabase.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameDatabaseDbContext _context;

        public GamesController(GameDatabaseDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string platform)
        {
            if (platform != null)
            {
                var model = await _context.Games.Where(p => p.Platform == platform).Select(m => new GameViewModel
                {
                    Description = m.Description,
                    Developer = m.Developer,
                    Name = m.Name,
                    Platform = m.Platform,
                    Publisher = m.Publisher,
                    Genre = m.Genre,
                    Id = m.Id
                }).ToListAsync();

                return View(model);
            }
            else
            {
                var model = await _context.Games.Select(m => new GameViewModel
                {
                    Description = m.Description,
                    Developer = m.Developer,
                    Name = m.Name,
                    Platform = m.Platform,
                    Publisher = m.Publisher,
                    Genre = m.Genre,
                    Id = m.Id
                }).ToListAsync();

                return View(model);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CoverArtUrl,Developer,Publisher,Description, Platform, Genre")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CoverArtUrl,Developer,Publisher,Description, Platform, Genre")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
