using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface ICommonService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<string> GenreName(decimal key);
        Task FavouriteGame(int gameId, int userId, bool isFavourited);
        Task<bool> CheckIfFavourited(int gameId, int userId);
    }
}
