using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameDatabase.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Author { get; set; }

        public int GameId { get; set; }
        [Required]
        public Game Game { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Text { get; set; }
    }
}
