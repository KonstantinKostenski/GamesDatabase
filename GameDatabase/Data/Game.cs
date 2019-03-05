using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string CoverArtUrl { get; set; }

        [Required]
        [MaxLength(30)]
        public string Developer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Publisher { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
