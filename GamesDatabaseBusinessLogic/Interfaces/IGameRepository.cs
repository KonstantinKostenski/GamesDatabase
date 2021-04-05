using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IGameRepository: IAsyncRepository<Game>
    {
        Task<Game> GetGameAndReviewsById(int id);
        Task<IEnumerable<Game>> GetAllGames(int? pageNumber, int pageSize, bool isFavourites, int userId);
        Task<IEnumerable<Game>> SearchGames(SearchObjectGames searchObject);
    }
}
