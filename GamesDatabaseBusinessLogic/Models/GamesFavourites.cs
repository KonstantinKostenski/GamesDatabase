using System.Collections.Generic;

namespace GamesDatabaseBusinessLogic.Models
{
    public class GamesFavourites
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId {get; set;}
        public UserApi User { get; set; }
        public bool IsFavourited { get; set; }
    }
}
