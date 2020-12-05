using GameDatabase.Data.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface IDeveloperRepository: IAsyncRepository<Developer>
    {
        Task<IEnumerable<Developer>> GetAllDeveloeprs(int? pageNumber, int pageSize);

        Task<List<int>> GetGameByDeveloperId(int id);
    }
}
