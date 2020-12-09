using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicGames
    {
        Task<IEnumerable<Game>> GetAllGames(int? pageNumber, int pageSize);
        Task<Game> GetGameById(int id);
        Task<Game> GetGameAndReviewsById(int id);
        Task DeleteGame(int id);
        Task AddGame(Game game);
        Task UpdateGame(int id, Game game);
        Task<IEnumerable<Game>> SearchGames(SearchObjectGames searchObject);
    }
}
