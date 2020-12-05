using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class BusinessLogicDevelopers: IBusinessLogicDevelopers
    {
        private readonly IDeveloperRepository _repository;

        public BusinessLogicDevelopers(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDeveloper(Developer developer)
        {
            await _repository.AddAsync(developer);
        }

        public bool CheckIfItCanBeDeleted(int id)
        {
            var result = _repository.GetGameByDeveloperId(id).Result.Count;
            return result <= 0;
        }

        public async Task DeleteDeveloper(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize)
        {
            return await this._repository.GetAllDeveloeprs(pageNumber, pageSize);
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateDeveloper(int id, Developer developer)
        {
            var developerFromDb = await this._repository.GetByIdAsync(id);
            developerFromDb.Description = developer.Description;
            developerFromDb.GamesDeveloped = developer.GamesDeveloped;
            developerFromDb.Location = developer.Location;
            developerFromDb.LogoUrl = developer.LogoUrl;
            developerFromDb.Name = developer.Name;
            await this._repository.UpdateAsync(developerFromDb);
        }
    }
}
