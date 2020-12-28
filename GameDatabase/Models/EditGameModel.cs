using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.Models
{
    public class EditGameModel
    {
        public string Name { get; set; }

        public string CoverArtUrl { get; set; }

        public string Genre { get; set; }

        public string GenreId { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public string Description { get; set; }

        public string Platform { get; set; }

        public int Id { get; set; }
    }
}
