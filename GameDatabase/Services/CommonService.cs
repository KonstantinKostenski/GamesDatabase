using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class CommonService: ICommonService
    {
        private ICommon _businessLogicCommon;

        public CommonService(ICommon businessLogicCommon)
        {
            _businessLogicCommon = businessLogicCommon;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _businessLogicCommon.GetAllGenresAsync();
        }

        public async Task<string> GenreName(decimal key)
        {
            return await _businessLogicCommon.GetGenreName(key);
        }
    }
}
