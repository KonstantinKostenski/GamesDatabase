using GameDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class CommonBusinessLogic
    {
        private readonly GameDatabaseDbContext _context;

        public CommonBusinessLogic(GameDatabaseDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await this._context.Genres.ToListAsync();
        }

        public string GetGenreName(decimal key)
        {
            return this._context.Genres.FindAsync(key).Result.Name;
        }
    }
}
