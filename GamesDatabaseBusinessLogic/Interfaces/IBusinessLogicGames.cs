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
        void DeleteGame(int id);
        void AddGame(Game game);
        void UpdateGame(int id, Game game);
    }
}
