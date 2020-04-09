using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class PublisherRepository : EfRepository<Publisher>
    {
        public PublisherRepository(GameDatabaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Publisher>> GetAllPublishers(int? pageNumber, int pageSize)
        {
            return await _dbContext.Publishers
             .Skip((pageNumber.Value == 1 ? 0 : pageNumber.Value * pageSize))
             .Take(pageSize)
             .ToListAsync();
        }
    }
}
