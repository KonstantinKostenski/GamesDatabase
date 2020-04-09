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

        void DeleteDeveloperById(int id);

        Task AddDeveloper(Developer model);

        void UpdateDeveloperById(int id, Developer model);
    }
}
