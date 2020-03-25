using System;
using System.Collections.Generic;
using System.Text;

namespace GameDatabase.Data
{
    public class DeveloperRepository : EfRepository<Developer>
    {
        public DeveloperRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
