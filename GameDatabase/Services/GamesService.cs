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

        public async Task<IEnumerable<GameViewModel>> GetAllGames(int? pageNumber, int pageSize)
        {
            var result = await _businessLogicGames.GetAllGames(pageNumber ?? 1, pageSize);
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
            var model = _mapper.Map<Game, GameViewModel>(game);
            return model;
        }

        public async Task AddGame(CreateGameModel createGameModel)
        {
            var game = new Game() { Name = createGameModel.Name, Description = createGameModel.Description, CoverArtUrl = createGameModel.CoverArtUrl, Genre = createGameModel.Genre, Platform = createGameModel.Platform };
            var developer = await _developerService.GetDeveloperByNameAsync(createGameModel.Developer);
            var publisher = await _publisherService.GetPublisherByNameAsync(createGameModel.Publisher);

            if (developer == null)
            {
                developer = new Developer() { Name = createGameModel.Developer, Description = "No description yet.", Location = "No location yet.", LogoUrl = "https://images.app.goo.gl/piYLgvJBbpcKbT9A7" };
                await _businessLogicDevelopers.AddDeveloper(developer);
            }

            if (publisher == null)
            {
                publisher = new Publisher() { Name = createGameModel.Publisher, Description = "No description yet.", Location = "No location yet.", LogoUrl = "https://images.app.goo.gl/piYLgvJBbpcKbT9A7" };
                await _businessLogicPublisher.AddPublsherAsync(publisher);
            }

            await _businessLogicDevelopers.SaveChangesAsync();
            await _businessLogicPublisher.SaveChangesAsync();
            developer = await _businessLogicDevelopers.GetDeveloperByNameAsync(createGameModel.Developer);
            publisher = await _businessLogicPublisher.GetPublisherByNameAsync(createGameModel.Publisher);
            game.DeveloperId = developer.Id;
            game.PublisherId = publisher.Id;
            await _businessLogicGames.AddGame(game);
            await _businessLogicGames.SaveChangesAsync();
        }

        public async Task UpdateGameById(int id, EditGameModel model)
        {
            Game game = new Game() { Name = model.Name, CoverArtUrl = model.CoverArtUrl, Description = model.Description, Platform = model.Platform, GenreId = model.GenreId, Genre = _commonService.GenreName(model.GenreId) };
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
