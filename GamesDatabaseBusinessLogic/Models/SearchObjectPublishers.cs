using GamesDatabaseBusinessLogic.Models.Interfaces;

namespace GamesDatabaseBusinessLogic.Models
{
    public class SearchObjectPublishers : ISearchObject
    {
        public string Name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
    }
}
