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

        public async Task UpdatePublisherAsync(int id, Publisher publisher)
        {
            var publisherFromDb = await GetPublisherByIdAsync(id);
            publisherFromDb.Description = publisher.Description;
            publisherFromDb.Location = publisher.Location;
            publisherFromDb.LogoUrl = publisher.LogoUrl;
            publisherFromDb.Name = publisher.Name;
            await this._publisherRepository.UpdateAsync(publisherFromDb);
        }

        public async Task DeletePublisherById(int id)
        {
            var publisherFromDb = await _publisherRepository.GetByIdAsync(id);
            await _publisherRepository.DeleteAsync(publisherFromDb);
        }

    }


}
