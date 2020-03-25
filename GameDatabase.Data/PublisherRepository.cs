using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase.Data
{
    public class PublisherRepository : EfRepository<Publisher>
    {
        public PublisherRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
