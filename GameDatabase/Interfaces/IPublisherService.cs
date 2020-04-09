using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishers(int? pageNumber, int pageSize);

        Task<Publisher> GetPublisherById(int id);

        void DeletePublisherById(int id);

        Task AddPublisherAsync(Publisher model);

        void UpdatePublisherById(int id, Publisher model);
    }
}
