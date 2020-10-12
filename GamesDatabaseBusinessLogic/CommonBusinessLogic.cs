using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class CommonBusinessLogic: ICommon
    {
        private readonly GameDatabaseDbContext _context;

        public CommonBusinessLogic(GameDatabaseDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public string GetGenreName(decimal key)
        {
            return _context.Genres.FindAsync(key).Result.Name;
        }
    }
}
