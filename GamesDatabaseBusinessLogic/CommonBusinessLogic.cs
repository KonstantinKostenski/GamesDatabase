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

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await this._context.GetAllGenres();
        }

        public string GetGenreName(decimal key)
        {
            throw new System.NotImplementedException();
        }
    }
}
