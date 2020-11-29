﻿using GameDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IGamesService
    {
        Task<IEnumerable<GameViewModel>> GetAllGames(int? pageNumber, int pageSize);

        Task<IEnumerable<GameViewModel>> GetAllGamesByGenre(int? pageNumber, int pageSize, int genreId);

        Task<GameViewModel> GetGameById(int id);

        Task DeleteGameById(int id);

        Task UpdateGameById(int id, EditGameModel model);
    }
}