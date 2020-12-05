using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic.Interfaces
{
    public interface ICommonRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        string GetGenreName(decimal key);
    }
}
