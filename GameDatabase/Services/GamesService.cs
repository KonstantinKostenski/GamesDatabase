using GameDatabase.Data;
using GameDatabase.Interfaces;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class GamesService : IGamesService
    {
        private IBusinessLogicGames _businessLogicGames;
        private CommonService _commonService;


        public GamesService(IBusinessLogicGames businessLogicGames, CommonService commonService)
        {
            _businessLogicGames = businessLogicGames;
            _commonService = commonService;
        }

        public IEnumerable<GameViewModel> GetAllGames(int? pageNumber, int pageSize)
        {
            return _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize).Result.Select(game => new GameViewModel
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

        public IEnumerable<GameViewModel> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId)
        {
            return _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize).Result.Where(game => game.GenreId == genreId).Select(game => new GameViewModel
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
        }

        public void UpdateGameById(int id, EditGameModel model)
        {
            Game game = new Game() { Name = model.Name, CoverArtUrl = model.CoverArtUrl, Description = model.Description, Platform = model.Platform, GenreId = model.GenreId, Genre = _commonService.GenreName(model.GenreId) };
            _businessLogicGames.UpdateGame(id, game);
        }

        public void DeleteGame(int id)
        {
            _businessLogicGames.DeleteGame(id);
        }

        public void DeleteGameById(int id)
        {
            _businessLogicGames.DeleteGame(id);
        }
    }
}
