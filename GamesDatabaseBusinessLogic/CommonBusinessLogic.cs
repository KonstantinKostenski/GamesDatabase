using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabaseBusinessLogic
{
    public class CommonBusinessLogic: ICommon
    {
        private readonly ICommonRepository _context;

        public CommonBusinessLogic(ICommonRepository context)
        {
            this._context = context;
        }

        public Task<IEnumerable<Genre>> GetAllGenres()
        {
            throw new System.NotImplementedException();
        }

        public string GetGenreName(decimal key)
        {
            throw new System.NotImplementedException();
        }
    }
}
