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

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Developer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Publisher { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Genre { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }

        public ICollection<Review> Reviews  { get; set; }
    }
}
