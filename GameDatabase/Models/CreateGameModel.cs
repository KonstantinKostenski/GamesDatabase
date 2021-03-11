using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Models
{
    public class CreateGameModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string CoverArtUrl { get; set; }
        
        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public string DeveloperName { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; }

        public string Genre { get; set; }

        [Required]
        public string GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<SelectListItem> Genres {get ;set;}

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
