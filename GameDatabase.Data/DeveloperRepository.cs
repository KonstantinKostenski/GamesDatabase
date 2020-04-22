using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class DeveloperRepository : EfRepository<Developer>
    {
        public DeveloperRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Developer>> GetAllDeveloeprs(int? pageNumber, int pageSize)
        {
            return await _dbContext.Developers
             .Skip(((pageNumber ?? 1) == 1 ? 0 : pageNumber.Value * pageSize))
             .Take(pageSize)
             .ToListAsync();
        }

        public async Task<List<int>> GetGameByDeveloperId(int id)
        {
            return await _dbContext.Games
             .Where(game => game.DeveloperId == id)
             .Select(game => game.Id)
             .ToListAsync();
        }
    }
}
