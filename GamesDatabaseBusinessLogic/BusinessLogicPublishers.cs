using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicPublishers : IBusinessLogicPublisher
    {
        private PublisherRepository _publisherRepository;

        public BusinessLogicPublishers(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<List<Publisher>> GetPublisherListAsync(int? pageNumber, int pageSize)
        {
            return await _publisherRepository.GetAllPublishers(pageNumber, pageSize);
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }

        public async Task AddPublsherAsync(Publisher publisher)
        {
            await _publisherRepository.AddAsync(publisher);
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
