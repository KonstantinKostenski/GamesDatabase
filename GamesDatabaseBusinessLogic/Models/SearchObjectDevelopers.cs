using GamesDatabaseBusinessLogic.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameDatabase
{
    public class SearchObjectDevelopers : ISearchObject
    {
        public string Name { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}