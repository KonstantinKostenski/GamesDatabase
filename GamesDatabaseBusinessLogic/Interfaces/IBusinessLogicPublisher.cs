using GameDatabase.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicPublisher
    {
        Task<List<Publisher>> GetPublisherListAsync(int? pageNumber, int pageSize);
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task AddPublsherAsync(Publisher publisher);
    }
}
