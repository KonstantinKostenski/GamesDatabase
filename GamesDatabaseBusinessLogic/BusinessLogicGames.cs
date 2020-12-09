using GameDatabase.Data;
using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicGames : IBusinessLogicGames
    {
        private readonly IGameRepository _gameRepository;

        public BusinessLogicGames(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGames(int? pageNumber, int pageSize)
        {
            //_gameRepository.UseStoredProcedure();
            return await _gameRepository.GetAllGames(pageNumber, pageSize);
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }

        public async Task<Game> GetGameAndReviewsById(int id)
        {
            return await _gameRepository.GetGameAndReviewsById(id);
        }

        public async Task DeleteGame(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            await _gameRepository.DeleteAsync(game);
        }

        public async Task AddGame(Game game)
        {
            await _gameRepository.AddAsync(game);
        }

        public async Task UpdateGame(int id, Game data)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            game.CoverArtUrl = data.CoverArtUrl;
            game.Description = data.Description;
            game.Name = data.Name;
            game.Genre = data.Genre;
            game.Name = data.Name;
            await _gameRepository.UpdateAsync(game);
        }

        public async Task<IEnumerable<Game>> SearchGames(SearchObjectGames searchObject)
        {
            return await this._gameRepository.SearchGames(searchObject);
        }
    }
}
