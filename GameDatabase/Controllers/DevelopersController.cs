﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Models;

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
            SearchObjectDevelopers searchObject = new SearchObjectDevelopers();
            return View(PaginatedList<Developer, SearchObjectDevelopers>.Create(model, pageNumber ?? 1, pageSize, searchObject));
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _developerService.GetDeveloperByIdAsync(id.Value);

            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location, LogoUrl, Description,Id")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                await _developerService.AddDeveloper(developer);
                return RedirectToAction(nameof(Index));
            }
            return View(developer);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _developerService.GetDeveloperByIdAsync(id.Value);

            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Location, LogoUrl, Description,Id")] Developer developer)
        {
            if (id != developer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _developerService.UpdateDeveloperByIdAsync(id, developer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var result = await DeveloperExistsAsync(developer.Id);

                    if (!result)
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

            return View(developer);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _developerService.GetDeveloperByIdAsync(id.Value);

            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            var canBeDeleted = await _developerService.CheckiIfItCanBeDeletedAsync(id);

            if (canBeDeleted)
            {
                await _developerService.DeleteDeveloperById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DeveloperExistsAsync(int id)
        {
            var result = await _developerService.GetDeveloperByIdAsync(id);
            return result != null;
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Search(SearchObjectDevelopers searchObject)
        {
            var pageSize = 10;
            var model = await _developerService.Search(searchObject);
            return View("~/Views/Developers/Index.cshtml", PaginatedList<Developer, SearchObjectDevelopers>.Create(model, 1, pageSize, searchObject));
        }
    }
}
