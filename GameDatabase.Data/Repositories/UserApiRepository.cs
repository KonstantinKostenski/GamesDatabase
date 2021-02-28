using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.Data.Repositories
{
    public class UserApiRepository : EfRepository<UserApi>, IUserApiRepository
    {
        public UserApiRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
