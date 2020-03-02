using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Data
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public int GameId { get; set; }

        public User Author { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Text { get; set; }
    }
}
