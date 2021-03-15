using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;
using GameDatabase.Models;
using GameDatabase.Interfaces;
using AutoMapper;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameDatabaseDbContext _context;
        private readonly IGamesService _gamesService;
        IMapper _mapper;
        ICommonService _commonService;

        public GamesController(GameDatabaseDbContext context, IGamesService gamesService, IMapper mapper, ICommonService commonService)
        {
            _context = context;
            _gamesService = gamesService;
            _commonService = commonService;
            _mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<IEnumerable<GameViewModel>> GetGames(int pageNumber, int pageSize)
        {
            IEnumerable<GameViewModel> model;
            model = await _gamesService.GetAllGames(pageNumber, pageSize);
            return model;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame([FromRoute] int id, [FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(game);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody] CreateGameModel game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            }

            var saveGameObject = _mapper.Map<CreateGameModel, Game>(game);
            saveGameObject.Genre = await _commonService.GenreName(saveGameObject.GenreId);
            _context.Games.Add(saveGameObject);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGame", new { id = saveGameObject.Id }, saveGameObject);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return Ok(game);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchObjectGames searchObject)
        {
            IEnumerable<GameViewModel> model;
            model = await _gamesService.SearchGames(searchObject);
            return Ok(model);
        }

        //public async Task<IActionResult> Favourite(int gameId)
        //{
            
        //}

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}