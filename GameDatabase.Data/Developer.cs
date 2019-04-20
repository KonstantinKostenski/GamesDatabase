using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameDatabase.Data
{
    public class Developer : BaseEntity
    {
        public Developer()
        {
            this.GamesDeveloped = new HashSet<Game>();
        }

        [Required]
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Location { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Description { get; set; }

        public ICollection<Game> GamesDeveloped { get; set; }
    }
}
