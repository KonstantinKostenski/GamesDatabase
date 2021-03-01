using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameDatabase.Data.Repositories
{
    public class UserApiRepository : EfRepository<UserApi>, IUserApiRepository
    {
        public UserApiRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserApi> GetUserByNameAndPassword(string userName, string password)
        {
            return await _dbContext.UserApi.FirstOrDefaultAsync(user => user.Username == userName && user.Password == password);
        }
    }
}
