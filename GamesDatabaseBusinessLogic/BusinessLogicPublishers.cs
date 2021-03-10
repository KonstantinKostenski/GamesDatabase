using GameDatabase;
using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicPublishers : IBusinessLogicPublisher
    {
        private IPublisherRepository _publisherRepository;

        public BusinessLogicPublishers(IPublisherRepository publisherRepository)
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
            this._publisherRepository.Update(publisherFromDb);
        }

        public async Task DeletePublisherById(int id)
        {
            var publisherFromDb = await _publisherRepository.GetByIdAsync(id);
            _publisherRepository.Delete(publisherFromDb);
        }

        public async Task<Publisher> GetPublisherByNameAsync(string name)
        {
            return await _publisherRepository.GetByNameAsync(name);
        }

        public async Task SaveChangesAsync()
        {
            await _publisherRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Publisher>> SearchAsync(SearchObjectPublishers searchObject)
        {
            return await _publisherRepository.SearchAsync(searchObject);
        }
    }


}
