using GameDatabase.Data;
using GamesDatabaseBusinessLogic;
using System.Collections.Generic;

namespace GameDatabase.Services
{
    public class CommonService
    {
        private CommonBusinessLogic _businessLogicCommon;

        public CommonService(CommonBusinessLogic businessLogicCommon)
        {
            this._businessLogicCommon = businessLogicCommon;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return this._businessLogicCommon.GetAllGenres().Result;
        }

        public string GenreName(decimal key)
        {
            return this._businessLogicCommon.GetGenreName(key);
        }
    }
}
