using GameDatabase;
using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IPublisherRepository: IAsyncRepository<Publisher>
    {
        Task<List<Publisher>> GetAllPublishers(int? pageNumber, int pageSize);
        Task<Publisher> GetByNameAsync(string name);
        Task<IEnumerable<Publisher>> SearchAsync(SearchObjectDevelopers searchObject);
    }
}
