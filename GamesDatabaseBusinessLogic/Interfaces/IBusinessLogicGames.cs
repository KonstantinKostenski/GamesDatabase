using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicGames
    {
        Task<List<Game>> GetAllGames(int? pageNumber, int pageSize);
        Task<Game> GetGameById(int id);
        Task<Game> GetGameAndReviewsById(int id);
        Task DeleteGame(int id);
        Task AddGame(int id);
        Task UpdateGame(int id, Game game);
    }
}
