using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishers(int? pageNumber, int pageSize);

        Task<Publisher> GetPublisherById(int id);

        Task DeletePublisherByIdAsync(int id);

        Task AddPublisherAsync(Publisher model);

        Task UpdatePublisherById(int id, Publisher model);
    }
}
