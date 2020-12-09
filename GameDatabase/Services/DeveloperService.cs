using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
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

        public async Task<bool> CheckiIfItCanBeDeletedAsync(int id)
        {
            return await _businessLogicDevelopers.CheckIfItCanBeDeletedAsync(id);
        }

        public async Task DeleteDeveloperById(int id)
        {
            await _businessLogicDevelopers.DeleteDeveloper(id);
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize)
        {
            return await _businessLogicDevelopers.GetAllDevelopers(pageNumber, pageSize);
        }

        public Task<Developer> GetDeveloperById(int id)
        {
            return _businessLogicDevelopers.GetDeveloperByIdAsync(id);
        }

        public async Task UpdateDeveloperByIdAsync(int id, Developer model)
        {
            await _businessLogicDevelopers.UpdateDeveloper(id, model);
        }
    }
}
