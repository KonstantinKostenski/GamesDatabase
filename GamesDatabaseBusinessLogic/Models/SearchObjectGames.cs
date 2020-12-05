using GamesDatabaseBusinessLogic.Models.Interfaces;

namespace GamesDatabaseBusinessLogic.Models
{
    public class SearchObjectGames: ISearchObject
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public decimal GenreId { get; set; }
    }
}