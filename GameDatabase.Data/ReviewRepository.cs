using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase.Data
{
    public class ReviewRepository : EfRepository<Review>
    {
        public ReviewRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
