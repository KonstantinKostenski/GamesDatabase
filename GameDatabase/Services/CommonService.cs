using GameDatabase.Data;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Interfaces;
using System.Collections.Generic;

namespace GameDatabase.Services
{
    public class CommonService: ICommonService
    {
        private ICommon _businessLogicCommon;

        public CommonService(ICommon businessLogicCommon)
        {
            _businessLogicCommon = businessLogicCommon;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _businessLogicCommon.GetAllGenres().Result;
        }

        public string GenreName(decimal key)
        {
            return _businessLogicCommon.GetGenreName(key);
        }
    }
}
