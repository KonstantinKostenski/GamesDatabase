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
            await _businessLogicDevelopers.SaveChangesAsync();
        }

        public async Task<bool> CheckiIfItCanBeDeletedAsync(int id)
        {
            return await _businessLogicDevelopers.CheckIfItCanBeDeletedAsync(id);
        }

        public async Task DeleteDeveloperById(int id)
        {
            await _businessLogicDevelopers.DeleteDeveloper(id);
            await _businessLogicDevelopers.SaveChangesAsync();
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize)
        {
            return await _businessLogicDevelopers.GetAllDevelopers(pageNumber, pageSize);
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return await _businessLogicDevelopers.GetDeveloperByIdAsync(id);
        }

        public async Task<Developer> GetDeveloperByNameAsync(string name)
        {
            return await _businessLogicDevelopers.GetDeveloperByNameAsync(name);
        }

        public async Task UpdateDeveloperByIdAsync(int id, Developer model)
        {
            await _businessLogicDevelopers.UpdateDeveloper(id, model);
            await _businessLogicDevelopers.SaveChangesAsync();
        }

        public async Task<IEnumerable<Developer>> Search(SearchObjectDevelopers searchObject)
        {
            return await _businessLogicDevelopers.SearchAsync(searchObject);
        }
    }
}
