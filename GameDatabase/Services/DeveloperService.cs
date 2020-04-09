using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class DeveloperService : IDeveloperService
    {
        private IBusinessLogicDevelopers _businessLogicDevelopers;

        public DeveloperService(IBusinessLogicDevelopers businessLogicDevelopers)
        {
            _businessLogicDevelopers = businessLogicDevelopers;
        }

        public async Task AddDeveloper(Developer model)
        {
            await _businessLogicDevelopers.AddDeveloper(model);
        }

        public void DeleteDeveloperById(int id)
        {
            _businessLogicDevelopers.DeleteDeveloper(id);
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize)
        {
            return await _businessLogicDevelopers.GetAllDevelopers(pageNumber, pageSize);
        }

        public Task<Developer> GetDeveloperById(int id)
        {
            return _businessLogicDevelopers.GetDeveloperByIdAsync(id);
        }

        public void UpdateDeveloperById(int id, Developer model)
        {
            _businessLogicDevelopers.UpdateDeveloper(id, model);
        }
    }
}
