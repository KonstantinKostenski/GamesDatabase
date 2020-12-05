using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDatabase
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public SearchObjectGames SearchObject { get; set; }
        public IEnumerable<SelectListItem> SelectListItems { get; set; }


        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize, IEnumerable<SelectListItem> selectListItems, SearchObjectGames searchObject)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            SearchObject = searchObject;
            SelectListItems = selectListItems;
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize, IEnumerable<SelectListItem> listItems, SearchObjectGames searchObject)
        {
            var count = source.Count();
            var items = source;
            return new PaginatedList<T>(items, count, pageIndex, pageSize,listItems, searchObject);
        }
    }
}
