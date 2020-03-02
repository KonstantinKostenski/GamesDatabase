using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class GameRepository : EfRepository<Game>
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

        public async Task<List<Game>> GetAllGames(int? pageNumber, int pageSize)
        {
            return await _dbContext.Games
             .Include(g => g.Developer)
             .Include(g => g.Publisher)
             .Skip((pageNumber.Value == 1 ? 0 : pageNumber.Value * pageSize))
             .Take(pageSize)
             .ToListAsync();
        }
    }
}
