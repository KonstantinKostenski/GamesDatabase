﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Models
{
    public class ReviewCreateModel
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
