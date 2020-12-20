using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class PublisherService : IPublisherService
    {
        private IBusinessLogicPublisher _businessLogicPublishers;

        public PublisherService(IBusinessLogicPublisher businessLogicPublishers)
        {
            this._businessLogicPublishers = businessLogicPublishers;
        }

        public async Task AddPublisherAsync(Publisher model)
        {
            await this._businessLogicPublishers.AddPublsherAsync(model);
        }

        public async Task DeletePublisherByIdAsync(int id)
        {
            await _businessLogicPublishers.DeletePublisherById(id);
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers(int? pageNumber, int pageSize) => await _businessLogicPublishers.GetPublisherListAsync(pageNumber, pageSize);

        public async Task<Publisher> GetPublisherByIdAsync(int id) => await _businessLogicPublishers.GetPublisherByIdAsync(id);

        public async Task<Publisher> GetPublisherByNameAsync(string name)
        {
            return await _businessLogicPublishers.GetPublisherByNameAsync(name);
        }

        public async Task UpdatePublisherById(int id, Publisher model)
        {
            await _businessLogicPublishers.UpdatePublisherAsync(id, model);
        }

    }
}
