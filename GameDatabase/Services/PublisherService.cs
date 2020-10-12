using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using System;
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

        public void DeletePublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers(int? pageNumber, int pageSize) => await _businessLogicPublishers.GetPublisherListAsync(pageNumber, pageSize);

        public Task<Publisher> GetPublisherById(int id) => _businessLogicPublishers.GetPublisherByIdAsync(id);

        public void UpdatePublisherById(int id, Publisher model)
        {
            throw new NotImplementedException();
        }

    }
}
