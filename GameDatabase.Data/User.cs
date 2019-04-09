using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GameDatabase.Data
{
    public class User : IdentityUser
    {

        public User()
        {
            this.Reviews = new HashSet<Review>();
        }

        public ICollection<Review> Reviews { get; set; }
    }
}