using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GameDatabase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using GameDatabase.Interfaces;

using AutoMapper;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.Controllers
{
    public class GamesController : Controller
    {
        private IGamesService _gamesService;
        private ICommonService _commonService;
        private IMapper _mapper;

        public GamesController(IGamesService gamesService, ICommonService commonService, IMapper mapper)
        {
            this._gamesService = gamesService;
            this._commonService = commonService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string platform, int? pageNumber)
        {
            var genres = await this._commonService.GetAllGenres();
            List<SelectListItem> ddlItems = new List<SelectListItem>();
            foreach (var genreItem in genres)
            {
                SelectListItem item = new SelectListItem(genreItem.Name, genreItem.Key.ToString());
                ddlItems.Add(item);
            }
            SearchObjectGames searchObject = new SearchObjectGames();
            searchObject.Genres = ddlItems;
            int pageSize = 10;
            IEnumerable<GameViewModel> model;
            model = await _gamesService.GetAllGames(pageNumber, pageSize);
            return View(PaginatedList<GameViewModel, SearchObjectGames>.Create(model, pageNumber ?? 1, pageSize, searchObject));
        }

        [HttpPost]
        public async Task<IActionResult> SearchGames(SearchObjectGames searchObject)
        {
            int pageSize = 10;
            int pageNumber = 1;
            var genres = await this._commonService.GetAllGenres();
            List<SelectListItem> ddlItems = new List<SelectListItem>();
            foreach (var genreItem in genres)
            {
                SelectListItem item = new SelectListItem(genreItem.Name, genreItem.Key.ToString());
                ddlItems.Add(item);
            }
            searchObject.Genres = ddlItems;
            IEnumerable<GameViewModel> model;
            model = await _gamesService.SearchGames(searchObject);
            return View("~/Views/Games/Index.cshtml", PaginatedList<GameViewModel, SearchObjectGames>.Create(model, pageNumber, pageSize, searchObject));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameById(id);

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
                await _gamesService.AddGame(game);
                return RedirectToAction(nameof(GamesController.Index), new { pageNumber = 1 });
            }

            return View(game);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var gameFromDatabase = await _gamesService.GetGameById(id);

            var game = _mapper.Map<GameViewModel, EditGameModel>(gameFromDatabase);

            var genres = await _commonService.GetAllGenres();

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var genre in genres)
            {
                var listItem = new SelectListItem(genre.Name, genre.Key.ToString());
                listItems.Add(listItem);
            }

            game.Genres = listItems;

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditGameModel game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _gamesService.UpdateGameById(id, game);

            }

            return View(game);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameById(id);

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
            await _gamesService.DeleteGameById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            //return _context.Games.Any(e => e.Id == id);
            return false;
        }
    }
}
