using GameDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IGamesService
    {
        IEnumerable<GameViewModel> GetAllGames(int? pageNumber, int pageSize);

        IEnumerable<GameViewModel> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId);

        Task<GameViewModel> GetGameById(int id);

        void DeleteGameById(int id);

        void UpdateGameById(int id, EditGameModel model);
    }
}
