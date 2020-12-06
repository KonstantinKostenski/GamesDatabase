using GamesDatabaseBusinessLogic.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GamesDatabaseBusinessLogic.Models
{
    public class SearchObjectGames: ISearchObject
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public decimal GenreId { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}