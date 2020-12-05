using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.Data
{
    public class GameRepository : EfRepository<Game>, IGameRepository
    {
        public GameRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Game> GetGameAndReviewsById(int id)
        {
            return await _dbContext.Games
                .Include(g => g.Reviews)
                .Include(g => g.Publisher)
                .Include(g => g.Developer)
                .FirstOrDefaultAsync(game => game.Id == id);
        }

        public async Task<IEnumerable<Game>> GetAllGames(int? pageNumber, int pageSize)
        {
            return await _dbContext.Games
             .Include(g => g.Developer)
             .Include(g => g.Publisher)
             .Skip((pageNumber.Value == 1 ? 0 : pageNumber.Value * pageSize))
             .Take(pageSize)
             .ToListAsync();
        }

        public async Task<IEnumerable<Game>> SearchGames(SearchObjectGames searchObject)
        {
            return await _dbContext.Games
             .Where(g =>  g.Name == searchObject.Name && g.Developer.Name == searchObject.Developer && g.Publisher.Name == searchObject.Publisher)
             .Include(g => g.Developer)
             .Include(g => g.Publisher)
             .Take(10)
             .ToListAsync();
        }

        public void UseStoredProcedure(int id = 3)
        {
            var game = _dbContext.Games
                      .FromSql($"GetGameById {id}").ToList()[0];
        }
    }
}
