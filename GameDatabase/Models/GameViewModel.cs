﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Models
{
    public class GameViewModel
    {
        public string Name { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public string Platform { get; set; }

        public object Id { get; set; }
    }
}
