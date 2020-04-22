using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;
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
        bool CheckIfItCanBeDeleted(int id);
    }
}
