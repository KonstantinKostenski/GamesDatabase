using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicPublishers
    {
        private PublisherRepository _publisherRepository;

        public BusinessLogicPublishers(PublisherRepository publisherRepository)
        {
            this._publisherRepository = publisherRepository;
        }

        public async Task<List<Publisher>> GetPublisherListAsync(int? pageNumber, int pageSize)
        {
            return await this._publisherRepository.GetAllPublishers(pageNumber, pageSize);
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            return await this._publisherRepository.GetByIdAsync(id);
        }

        public async Task AddPublsherAsync(Publisher publisher)
        {
            await this._publisherRepository.AddAsync(publisher);
        }

    }


}
