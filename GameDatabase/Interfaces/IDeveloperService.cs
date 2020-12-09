using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize);

        Task<Developer> GetDeveloperById(int id);

        Task DeleteDeveloperById(int id);

        Task AddDeveloper(Developer model);

        Task UpdateDeveloperByIdAsync(int id, Developer model);

        Task<bool> CheckiIfItCanBeDeletedAsync(int id);
    }
}
