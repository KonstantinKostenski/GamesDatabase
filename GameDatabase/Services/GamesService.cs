using GameDatabase.Data;
using GameDatabase.Interfaces;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using GamesDatabaseBusinessLogic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class GamesService : IGamesService
    {
        private IBusinessLogicGames _businessLogicGames;
        private ICommonService _commonService;


        public GamesService(IBusinessLogicGames businessLogicGames, ICommonService commonService)
        {
            _businessLogicGames = businessLogicGames;
            _commonService = commonService;
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGames(int? pageNumber, int pageSize)
        {
            var result = await _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize);

            return result.Select(game => new GameViewModel
            {
                Developer = game.Developer.Name,
                Publisher = game.Publisher.Name,
                Genre = game.Genre,
                Name = game.Name,
                CoverArtUrl = game.CoverArtUrl,
                Description = game.Description,
                Platform = game.Platform,
                Reviews = game.Reviews.Select(review => new ReviewViewModel
                {
                    Author = review.Author,
                    Id = review.Id,
                    Text = review.Text,
                    Title = review.Title
                }),
                Id = game.Id
            }).ToList();
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId)
        {
            var result = await _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize);
            return result.Where(game => game.GenreId == genreId).Select(game => new GameViewModel
            {
                Developer = game.Developer.Name,
                Publisher = game.Publisher.Name,
                Genre = game.Genre,
                Name = game.Name,
                CoverArtUrl = game.CoverArtUrl,
                Description = game.Description,
                Platform = game.Platform,
                Id = game.Id
            }).ToList();
        }

        public async Task<GameViewModel> GetGameById(int id)
        {
            var game = await _businessLogicGames.GetGameAndReviewsById(id);
            List<ReviewViewModel> reviewViewModels = new List<ReviewViewModel>();

            foreach (var review in game.Reviews)
            {
                reviewViewModels.Add(new ReviewViewModel() {Id = review.Id, Author = review.Author, Text = review.Text,
                    GameId = review.GameId, AuthorId = review.AuthorId, Title = review.Title });
            }

            var model = new GameViewModel() { Genre = game.Genre, GenreId = game.GenreId, CoverArtUrl = game.CoverArtUrl, Description = game.Description,
                Id = game.Id, Platform = game.Platform, Name = game.Name,
                Developer = game.Developer.Name, Publisher = game.Publisher.Name, Reviews = reviewViewModels };

            return model;
        }

        public void AddGame(CreateGameModel createGameModel)
        {
            var game = new Game() { Name = createGameModel.Name, Description = createGameModel.Description, CoverArtUrl = createGameModel.CoverArtUrl, Genre = createGameModel.Genre};
            _businessLogicGames.AddGame(game);
        }

        public  async Task UpdateGameById(int id, EditGameModel model)
        {
            Game game = new Game() { Name = model.Name, CoverArtUrl = model.CoverArtUrl, Description = model.Description, Platform = model.Platform, GenreId = model.GenreId, Genre = _commonService.GenreName(model.GenreId) };
            await _businessLogicGames.UpdateGame(id, game);
        }

        public async Task DeleteGame(int id)
        {
            await _businessLogicGames.DeleteGame(id);
        }

        public async Task DeleteGameById(int id)
        {
            await _businessLogicGames.DeleteGame(id);
        }

        public async Task<IEnumerable<GameViewModel>> SearchGames(SearchObjectGames searchObject)
        {
            var result = await this._businessLogicGames.SearchGames(searchObject);
            return result.Select(game => new GameViewModel
            {
                Developer = game.Developer.Name,
                Publisher = game.Publisher.Name,
                Genre = game.Genre,
                Name = game.Name,
                CoverArtUrl = game.CoverArtUrl,
                Description = game.Description,
                Platform = game.Platform,
                Id = game.Id
            }).ToList();
        }
    }
}
