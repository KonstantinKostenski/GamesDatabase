using AutoMapper;
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
        private IBusinessLogicDevelopers _businessLogicDevelopers;
        private IBusinessLogicPublisher _businessLogicPublisher;


        private ICommonService _commonService;
        private IDeveloperService _developerService;
        private IPublisherService _publisherService;
        private IMapper _mapper;

        public UserApi User { get; set; }

        public GamesService(IBusinessLogicGames businessLogicGames, IBusinessLogicDevelopers businessLogicDevelopers, IBusinessLogicPublisher businessLogicPublisher, ICommonService commonService, IDeveloperService developerService, IPublisherService publisherService, IMapper mapper)
        {
            _businessLogicGames = businessLogicGames;
            _businessLogicDevelopers = businessLogicDevelopers;
            _businessLogicPublisher = businessLogicPublisher;
            _commonService = commonService;
            _developerService = developerService;
            _publisherService = publisherService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGames(int? pageNumber, int pageSize, int userId)
        {
            var result = await _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize, userId);
            return _mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(result);
            //return result.Select(game => new GameViewModel
            //{
            //    Developer = game.Developer.Name,
            //    Publisher = game.Publisher.Name,
            //    Genre = game.Genre,
            //    Name = game.Name,
            //    CoverArtUrl = game.CoverArtUrl,
            //    Description = game.Description,
            //    Platform = game.Platform,
            //    Reviews = game.Reviews.Select(review => new ReviewViewModel
            //    {
            //        Author = review.Author,
            //        Id = review.Id,
            //        Text = review.Text,
            //        Title = review.Title
            //    }),
            //    Id = game.Id
            //}).ToList();
        }

        public async Task<IEnumerable<GameViewModel>> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId)
        {
            var result = await _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize, 0);
            return result.Where(game => game.GenreId == genreId).Select(game => new GameViewModel
            {
                DeveloperName = game.Developer.Name,
                PublisherName = game.Publisher.Name,
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
            var model = _mapper.Map<Game, GameViewModel>(game);
            return model;
        }

        public async Task AddGame(CreateGameModel createGameModel)
        {
            var game = _mapper.Map<CreateGameModel, Game>(createGameModel);
            var developer = await _developerService.GetDeveloperByNameAsync(createGameModel.DeveloperName);
            var publisher = await _publisherService.GetPublisherByNameAsync(createGameModel.PublisherName);

            if (developer == null)
            {
                developer = new Developer() { Name = createGameModel.DeveloperName, Description = "No description yet.", Location = "No location yet.", LogoUrl = "https://images.app.goo.gl/piYLgvJBbpcKbT9A7" };
                await _businessLogicDevelopers.AddDeveloper(developer);
            }

            if (publisher == null)
            {
                publisher = new Publisher() { Name = createGameModel.PublisherName, Description = "No description yet.", Location = "No location yet.", LogoUrl = "https://images.app.goo.gl/piYLgvJBbpcKbT9A7" };
                await _businessLogicPublisher.AddPublsherAsync(publisher);
            }

            await _businessLogicDevelopers.SaveChangesAsync();
            await _businessLogicPublisher.SaveChangesAsync();
            developer = await _businessLogicDevelopers.GetDeveloperByNameAsync(createGameModel.DeveloperName);
            publisher = await _businessLogicPublisher.GetPublisherByNameAsync(createGameModel.PublisherName);
            game.DeveloperId = developer.Id;
            game.PublisherId = publisher.Id;
            game.Genre = createGameModel.Genres.First(genre => decimal.Parse(genre.Value) == game.GenreId)?.Text;
            await _businessLogicGames.AddGame(game);
            await _businessLogicGames.SaveChangesAsync();
        }

        public async Task UpdateGameById(int id, EditGameModel model)
        {
            Game game = _mapper.Map<EditGameModel, Game>(model);
            game.Genre = model.Genres.First(genre => decimal.Parse(genre.Value) == game.GenreId)?.Text;
            await _businessLogicGames.UpdateGame(id, game);
            await _businessLogicGames.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            await _businessLogicGames.DeleteGame(id);
            await _businessLogicGames.SaveChangesAsync();
        }

        public async Task DeleteGameById(int id)
        {
            await _businessLogicGames.DeleteGame(id);
            await _businessLogicGames.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameViewModel>> SearchGames(SearchObjectGames searchObject)
        {
            var result = await this._businessLogicGames.SearchGames(searchObject);
            return result.Select(game => new GameViewModel
            {
                DeveloperName = game.Developer.Name,
                PublisherName = game.Publisher.Name,
                Genre = game.Genre,
                Name = game.Name,
                CoverArtUrl = game.CoverArtUrl,
                Description = game.Description,
                Platform = game.Platform,
                Id = game.Id
            }).ToList();
        }

        public Task AddGameToFavourites(int gameId)
        {
            return null;
        }
    }
}
