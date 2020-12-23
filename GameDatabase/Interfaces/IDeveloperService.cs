using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize);

        Task<Developer> GetDeveloperByIdAsync(int id);

        Task<Developer> GetDeveloperByNameAsync(string name);

        Task DeleteDeveloperById(int id);

        Task AddDeveloper(Developer model);

        Task UpdateDeveloperByIdAsync(int id, Developer model);

        Task<bool> CheckiIfItCanBeDeletedAsync(int id);

        Task<IEnumerable<Developer>> Search(SearchObjectDevelopers searchObject);
    }
}
