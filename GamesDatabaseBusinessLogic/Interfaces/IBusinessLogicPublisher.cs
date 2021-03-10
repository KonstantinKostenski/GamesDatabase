using GameDatabase;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicPublisher
    {
        Task<List<Publisher>> GetPublisherListAsync(int? pageNumber, int pageSize);
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<Publisher> GetPublisherByNameAsync(string name);
        Task AddPublsherAsync(Publisher publisher);
        Task DeletePublisherById(int id);
        Task UpdatePublisherAsync(int id, Publisher model);
        Task SaveChangesAsync();
        Task<IEnumerable<Publisher>> SearchAsync(SearchObjectPublishers searchObject);
    }
}
