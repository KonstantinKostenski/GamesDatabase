using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class CommonBusinessLogic: ICommon
    {
        private readonly ICommonRepository _context;

        public CommonBusinessLogic(ICommonRepository context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await this._context.GetAllGenres();
        }

        public async Task<string> GetGenreName(decimal key)
        {
            return await this._context.GetGenreName(key);
        }

        public async Task FavouriteGame(int gameId, int userId, bool isFavourited)
        {
            await _context.FavouriteGame(gameId, userId, isFavourited);
        }

        public async Task<bool> CheckIfFavourited(int gameId, int userId)
        {
            return await _context.CheckIfFavourited(gameId, userId);
        }
    }
}
