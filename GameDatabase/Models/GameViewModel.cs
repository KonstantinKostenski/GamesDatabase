using GameDatabase.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Models
{
    public class GameViewModel
    {
        public string Name { get; set; }

        public string CoverArtUrl { get; set; }

        public string AuthorName { get; set; }

        public int DeveloperId { get; set; }

        public string Developer { get; set; }

        public int PublisherId { get; set; }

        public string Publisher { get; set; }

        public string Genre { get; set; }

        public decimal GenreId { get; set; }

        public string Description { get; set; }

        public string Platform { get; set; }

        public int Id { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

    }
}
