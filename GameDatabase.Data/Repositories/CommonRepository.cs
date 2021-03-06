﻿using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class CommonRepository : ICommonRepository
    {
        GameDatabaseDbContext dbContext;

        public CommonRepository(GameDatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public async Task<string> GetGenreName(decimal key)
        {
            var genre = await dbContext.Genres.FindAsync(key);
            return genre.Name;
        }

        public async Task FavouriteGame(int gameId, int userId, bool isFavourited)
        {
            GamesFavourites gamesFavourites = await dbContext.Set<GamesFavourites>().FirstOrDefaultAsync(item => item.GameId == gameId && item.UserId == userId);

            if (gamesFavourites == null)
            {
                gamesFavourites = new GamesFavourites();
                gamesFavourites.GameId = gameId;
                gamesFavourites.UserId = userId;
                gamesFavourites.IsFavourited = isFavourited;
                await dbContext.Set<GamesFavourites>().AddAsync(gamesFavourites);
            }
            else
            {
                gamesFavourites.IsFavourited = isFavourited;
                dbContext.Entry(gamesFavourites).State = EntityState.Modified;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfFavourited(int gameId, int userId)
        {
            var result = await dbContext.GamesFavourites.FirstOrDefaultAsync(item => item.GameId == gameId && item.UserId == userId);
            return result != null ? result.IsFavourited : false;
        }
    }
}
