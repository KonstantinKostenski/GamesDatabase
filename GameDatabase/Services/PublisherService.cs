using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class PublisherService : IPublisherService
    {
        private BusinessLogicPublishers _businessLogicPublishers;

        public PublisherService(BusinessLogicPublishers businessLogicPublishers)
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

        public Task<Publisher> GetPublisherById(int id) => _businessLogicPublishers.GetPublisherByIdAsync(id);

        public async Task UpdatePublisherById(int id, Publisher model)
        {
            await _businessLogicPublishers.UpdatePublisherAsync(id, model);
        }

    }
}
