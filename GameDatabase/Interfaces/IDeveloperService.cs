using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        bool CheckiIfItCanBeDeleted(int id);
    }
}
