using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameDatabase.Models;
using Microsoft.AspNetCore.Authorization;
using GameDatabase.Interfaces;

namespace GameDatabase.Controllers
{
    public class ReviewsController : Controller
    {
        //private readonly GameDatabaseDbContext _context;
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewService)
        {
            this._reviewsService = reviewService;
            //            _context = context;
        }

        //        // GET: Reviews
        //        public async Task<IActionResult> Index()
        //        {
        //            var gameDatabaseDbContext = _context.Reviews.Include(r => r.Game);
        //            return View(await gameDatabaseDbContext.ToListAsync());
        //        }

        //        // GET: Reviews/Details/5
        //        public async Task<IActionResult> Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var review = await _context.Reviews
        //                .Include(r => r.Game)
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (review == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(review);
        //        }

        // GET: Reviews/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            ReviewCreateModel createModel = new ReviewCreateModel();
            createModel.GameId = id ?? 0;
            return View(createModel);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([FromRoute] int id, [Bind("Title,Text")] ReviewCreateModel review)
        {
            if (ModelState.IsValid)
            {
                await _reviewsService.AddReviewAsync(review, id, User);
                return RedirectToAction("Details", "Games", new { id });
            }

            return View(review);
        }

        //        // GET: Reviews/Edit/5
        //        [Authorize]
        //        public async Task<IActionResult> Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var review = await _context.Reviews.FindAsync(id);
        //            if (review == null)
        //            {
        //                return NotFound();
        //            }
        //            ViewData["GameId"] = new SelectList(_context.Games, "Id", "CoverArtUrl", review.GameId);
        //            return View(review);
        //        }

        //        // POST: Reviews/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [Authorize]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,Title,Text")] Review review)
        //        {
        //            if (id != review.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(review);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!ReviewExists(review.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            ViewData["GameId"] = new SelectList(_context.Games, "Id", "CoverArtUrl", review.GameId);
        //            return View(review);
        //        }

        //        // GET: Reviews/Delete/5
        //        [Authorize]
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var review = await _context.Reviews
        //                .Include(r => r.Game)
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (review == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(review);
        //        }

        //        // POST: Reviews/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [Authorize]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            var review = await _context.Reviews.FindAsync(id);
        //            _context.Reviews.Remove(review);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Details", "Games", new { id = review.GameId});
        //        }

        //        private bool ReviewExists(int id)
        //        {
        //            return _context.Reviews.Any(e => e.Id == id);
        //        }
        //    }
    }
}
