using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface ICommonRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<string> GetGenreName(decimal key);
        Task FavouriteGame(int gameId, int userId);
        Task<bool> CheckIfFavourited(int gameId, int userId);
    }
}
