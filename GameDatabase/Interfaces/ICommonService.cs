using GameDatabase.Data;
using System.Collections.Generic;

namespace GameDatabase.Interfaces
{
    public interface ICommonService
    {
        IEnumerable<Genre> GetAllGenres();
        string GenreName(decimal key);
    }
}
