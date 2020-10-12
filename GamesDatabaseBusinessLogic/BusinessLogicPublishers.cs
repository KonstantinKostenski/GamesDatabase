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

    }


}
