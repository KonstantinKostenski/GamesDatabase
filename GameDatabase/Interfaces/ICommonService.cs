using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Interfaces
{
    public interface ICommonService
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        string GenreName(decimal key);
    }
}
