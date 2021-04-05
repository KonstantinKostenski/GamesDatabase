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
        private readonly ICommon _commonBusinessLogic;

        public BusinessLogicGames(IGameRepository gameRepository, ICommon commonBusinessLogic)
        {
            _gameRepository = gameRepository;
            _commonBusinessLogic = commonBusinessLogic;
        }

        public async Task<IEnumerable<Game>> GetAllGames(int? pageNumber, int pageSize, int userId, bool isFavourites)
        {
            var gameList = await _gameRepository.GetAllGames(pageNumber, pageSize, isFavourites, userId);
            foreach (Game game in gameList)
            {
                game.IsFavouritedByUser = await _commonBusinessLogic.CheckIfFavourited(game.Id, userId);
            }
            return gameList; 
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
             _gameRepository.Delete(game);
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
            _gameRepository.Update(game);
        }

        public async Task<IEnumerable<Game>> SearchGames(SearchObjectGames searchObject)
        {
            return await this._gameRepository.SearchGames(searchObject);
        }

        //public async Task<IEnumerable<Game>> AddGameToFavourites(int gameId)
        //{
        //    return await this._gameRepository.fa(gameId);
        //}

        public async Task SaveChangesAsync()
        {
            await _gameRepository.SaveChangesAsync();
        }
    }
}
