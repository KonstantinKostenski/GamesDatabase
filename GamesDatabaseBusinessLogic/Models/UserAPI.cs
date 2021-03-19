using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GamesDatabaseBusinessLogic.Models
{
    public class UserApi: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public ICollection<GamesFavourites> GamesFavourites { get; set; }
    }
}
