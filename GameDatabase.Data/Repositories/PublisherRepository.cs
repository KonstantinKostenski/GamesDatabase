using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Data
{
    public class PublisherRepository : EfRepository<Publisher>, IPublisherRepository
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

        public async Task<Publisher> GetByNameAsync(string name)
        {
            return await _dbContext.Publishers.Where(publisher => publisher.Name == name).FirstOrDefaultAsync();
        }
    }
}
