using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Data
{
    public class User : IdentityUser
    {

        public User()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}