using GameDatabase.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicGames
    {
        Task<List<Game>> GetAllGames(int? pageNumber, int pageSize);
        Task<Game> GetGameById(int id);
        Task<Game> GetGameAndReviewsById(int id);
        Task DeleteGame(int id);
        void AddGame(Game game);
        Task UpdateGame(int id, Game game);
    }
}
