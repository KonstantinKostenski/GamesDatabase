using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
          _publisherService = publisherService;
        }

        // GET: Publishers
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var model = await _publisherService.GetAllPublishers(pageNumber ?? 1, 10);
            SearchObjectDevelopers searchObject = new SearchObjectDevelopers();
            int pageSize = 10;
            return View(PaginatedList<Publisher, SearchObjectDevelopers>.Create(model, pageNumber ?? 1, pageSize, searchObject));
        }

        //// GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetPublisherByIdAsync(id.Value);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location, LogoUrl, Description,Id")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.AddPublisherAsync(publisher);
                return RedirectToAction(nameof(Index));
            }

            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetPublisherByIdAsync(id.Value);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Location, LogoUrl, Description,Id")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _publisherService.UpdatePublisherById(publisher.Id, publisher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.Id))
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

            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetPublisherByIdAsync(id.Value);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _publisherService.DeletePublisherByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _publisherService.GetPublisherByIdAsync(id).Result != null;
        }


        // GET: Publishers/Delete/5
        public async Task<IActionResult> Search(SearchObjectPublishers searchObject)
        {
            var pageSize = 10;
            var model = await _publisherService.Search(searchObject);
            return View("~/Views/Publishers/Index.cshtml", PaginatedList<Publisher, SearchObjectDevelopers>.Create(model, 1, pageSize, searchObject));
        }
    }
}
