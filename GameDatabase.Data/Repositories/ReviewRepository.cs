using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.Data
{
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
