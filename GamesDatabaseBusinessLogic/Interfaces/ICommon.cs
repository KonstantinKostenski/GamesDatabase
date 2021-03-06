﻿using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface ICommon
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<string> GetGenreName(decimal key);
        Task FavouriteGame (int gameId, int userId, bool isFavourited);
        Task<bool> CheckIfFavourited(int gameId, int userId);
    }
}
