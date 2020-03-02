using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Data
{
    public class Game : BaseEntity
    {
        public Game()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string CoverArtUrl { get; set; }

        public int DeveloperId { get; set; }
        [Required]
        public Developer Developer { get; set; }

        public int PublisherId { get; set; }
        [Required]
        public Publisher Publisher { get; set; }

        public decimal GenreId { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }

        public ICollection<Review> Reviews  { get; set; }
    }
}
