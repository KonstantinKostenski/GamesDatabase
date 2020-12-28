using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishers(int? pageNumber, int pageSize);

        Task<Publisher> GetPublisherByIdAsync(int id);

        Task<Publisher> GetPublisherByNameAsync(string name);

        Task DeletePublisherByIdAsync(int id);

        Task AddPublisherAsync(Publisher model);

        Task UpdatePublisherById(int id, Publisher model);

        Task<IEnumerable<Publisher>> Search(SearchObjectDevelopers searchObject);
    }
}
