using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicGames : IBusinessLogicGames
    {
        private readonly GameRepository _gameRepository;

        public BusinessLogicGames(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<Game>> GetAllGames(int? pageNumber, int pageSize)
        {
            _gameRepository.UseStoredProcedure();
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

        public async void DeleteGame(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            await _gameRepository.DeleteAsync(game);
        }

        public async void AddGame(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            await _gameRepository.AddAsync(game);
        }

        public async void UpdateGame(int id, Game data)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            game.CoverArtUrl = data.CoverArtUrl;
            game.Description = data.Description;
            game.Name = data.Name;
            game.Genre = data.Genre;
            game.Name = data.Name;
            await _gameRepository.UpdateAsync(game);
        }
    }
}
