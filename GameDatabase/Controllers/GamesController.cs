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

        public async Task<IActionResult> Index(string platform, string genre, int? pageNumber)
        {
            if (platform != null || genre != null)
            {
                pageNumber = 1;
            }

            if (platform != null || genre != null)
            {
                var model =  _context.Games
                    .Include(g => g.Developer)
                    .Include(g => g.Publisher)
                    .Where(p => p.Platform == platform || p.Genre == genre)
                    .Select(m => new GameViewModel
                {
                    Description = m.Description,
                    DeveloperId = m.DeveloperId,
                    Developer = m.Developer.Name,
                    Name = m.Name,
                    Platform = m.Platform,
                    PublisherId = m.PublisherId,
                    Publisher = m.Publisher.Name,
                    Genre = m.Genre,
                    Id = m.Id
                });

                int pageSize = 10;
                return View(await PaginatedList<GameViewModel>.CreateAsync(model, pageNumber ?? 1, pageSize));
            }
            else
            {
                var model = _context.Games
                    .Include(g => g.Developer)
                    .Include(g => g.Publisher)
                    .Select(m => new GameViewModel
                {
                    Description = m.Description,
                    DeveloperId = m.DeveloperId,
                    Developer = m.Developer.Name,
                    Name = m.Name,
                    Platform = m.Platform,
                    PublisherId = m.PublisherId,
                    Publisher = m.Publisher.Name,
                    Genre = m.Genre,
                    Id = m.Id
                });

                int pageSize = 10;
                return View(await PaginatedList<GameViewModel>.CreateAsync(model, pageNumber ?? 1, pageSize));
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = this._context.Reviews.Include(r => r.Author).Where(r => r.GameId == id).ToArray();

            var game = await _context
                .Games
                .Include(g => g.Publisher)
                .Include(g => g.Developer)
                .Include(g => g.Reviews)
                .Select(g => new GameViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    CoverArtUrl = g.CoverArtUrl,
                    Platform = g.Platform,
                    PublisherId = g.PublisherId,
                    Publisher = g.Publisher.Name,
                    Description = g.Description,
                    DeveloperId = g.DeveloperId,
                    Developer = g.Developer.Name,
                    Genre = g.Genre,
                    Reviews = reviews
                })
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
        public async Task<IActionResult> Create([Bind("Id, Name, CoverArtUrl,Developer,Publisher,Description, Platform, Genre")] CreateGameModel game)
        {
           

            if (ModelState.IsValid)
            {
                var publisher = _context
               .Publishers
               .FirstOrDefault(p => p.Name == game.Publisher);

                var developer = _context
                    .Developers
                    .FirstOrDefault(d => d.Name == game.Developer);

                var newGame = new Game()
                {
                    CoverArtUrl = game.CoverArtUrl,
                    Name = game.Name,
                    Developer = developer,
                    Publisher = publisher,
                    Genre = game.Genre,
                    Platform = game.Platform,
                    Description = game.Description

                };


                _context.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GamesController.Index), new { pageNumber = 1});
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CoverArtUrl,Developer,Publisher,Description, Platform, Genre")] EditGameModel game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var gameFromDb = _context
                    .Games
                    .FirstOrDefault(g => g.Id == game.Id);

                gameFromDb.Name = game.Name;
                gameFromDb.Platform = game.Platform;
                gameFromDb.CoverArtUrl = game.CoverArtUrl;
                gameFromDb.Genre = game.Genre;
                gameFromDb.Description = game.Description;

                try
                {
                    _context.Update(gameFromDb);
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
