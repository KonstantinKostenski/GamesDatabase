using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IBusinessLogicDevelopers
    {
        Task<IEnumerable<Developer>> GetAllDevelopers(int? pageNumber, int pageSize);
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task DeleteDeveloper(int id);
        Task AddDeveloper(Developer developer);
        Task UpdateDeveloper(int id, Developer game);
        Task<bool> CheckIfItCanBeDeletedAsync(int id);
    }
}
