using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GameDatabase.Interfaces;

namespace GameDatabase.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        // GET: Developers
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var pageSize = 10;
            var model =  await _developerService.GetAllDevelopers(pageNumber, pageSize);
            return View(PaginatedList<Developer>.Create(model, pageNumber ?? 1, pageSize));
        }

//        // GET: Developers/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var developer = await _context.Developers
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (developer == null)
//            {
//                return NotFound();
//            }

//            return View(developer);
//        }

//        // GET: Developers/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Developers/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Name,Location, LogoUrl, Description,Id")] Developer developer)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(developer);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(developer);
//        }

//        // GET: Developers/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var developer = await _context.Developers.FindAsync(id);
//            if (developer == null)
//            {
//                return NotFound();
//            }
//            return View(developer);
//        }

//        // POST: Developers/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Name,Location, LogoUrl, Description,Id")] Developer developer)
//        {
//            if (id != developer.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(developer);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!DeveloperExists(developer.Id))
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
//            return View(developer);
//        }

//        // GET: Developers/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var developer = await _context.Developers
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (developer == null)
//            {
//                return NotFound();
//            }

//            return View(developer);
//        }

//        // POST: Developers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var developer = await _context.Developers.FindAsync(id);
//            _context.Developers.Remove(developer);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool DeveloperExists(int id)
//        {
//            return _context.Developers.Any(e => e.Id == id);
//        }
    }
}
