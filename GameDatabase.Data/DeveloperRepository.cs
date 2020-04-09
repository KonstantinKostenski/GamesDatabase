using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDatabase.Data
{
    public class DeveloperRepository : EfRepository<Developer>
    {
        public DeveloperRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }

        public async System.Threading.Tasks.Task<IEnumerable<Developer>> GetAllDeveloeprs(int? pageNumber, int pageSize)
        {
            return await _dbContext.Developers
             .Skip((pageNumber.Value == 1 ? 0 : pageNumber.Value * pageSize))
             .Take(pageSize)
             .ToListAsync();
        }
    }
}
