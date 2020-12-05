using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class CommonRepository : ICommonRepository
    {
        GameDatabaseDbContext dbContext;

        public CommonRepository(GameDatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public string GetGenreName(decimal key)
        {
            return dbContext.Genres.FindAsync(key).Result.Name;
        }
    }
}
