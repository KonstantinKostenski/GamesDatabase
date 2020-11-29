using GameDatabase.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface ICommon
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        string GetGenreName(decimal key);
    }
}
