using GameDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabaseBusinessLogic
{
    class BusinessLogicDevelopers
    {
        private readonly GameDatabaseDbContext _context;

        public BusinessLogicDevelopers(GameDatabaseDbContext context)
        {
            _context = context;
        }
    }
}
