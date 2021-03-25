﻿using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Models;
using GamesDatabaseBusinessLogic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IGamesService
    {
        UserApi User { get; set; }

        Task<IEnumerable<GameViewModel>> GetAllGames(int? pageNumber, int pageSize, int userId);

        Task<IEnumerable<GameViewModel>> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId);

        Task<GameViewModel> GetGameById(int id);

        Task DeleteGameById(int id);

        Task UpdateGameById(int id, EditGameModel model);

        Task AddGame(CreateGameModel gameModel);

        Task<IEnumerable<GameViewModel>> SearchGames(SearchObjectGames searchObject);

        Task AddGameToFavourites(int gameId);
    }
}
