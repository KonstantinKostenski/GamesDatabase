using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class DeveloperRepository : EfRepository<Developer>, IDeveloperRepository
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

        public async Task<Developer> GetDeveloperByName(string name)
        {
            return await _dbContext.Developers
             .FirstOrDefaultAsync(developer => developer.Name == name);
        }

        public async Task<List<int>> GetGameByDeveloperId(int id)
        {
            return await _dbContext.Games
             .Where(game => game.DeveloperId == id)
             .Select(game => game.Id)
             .ToListAsync();
        }

        public async Task<IEnumerable<Developer>> SearchAsync(SearchObjectDevelopers searchObject)
        {
            return await _dbContext.Developers
             .Where(developer => developer.Name == searchObject.Name)
             .ToListAsync();
        }
    }
}
