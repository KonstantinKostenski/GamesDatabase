using GamesDatabaseBusinessLogic.Models;
using GamesDatabaseBusinessLogic.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameDatabase
{
    public class PaginatedList<T, TSearch> : List<T> where TSearch :  class, ISearchObject
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<SelectListItem> SelectListItems { get; set; }
        public TSearch SearchObject { get; set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize, ISearchObject searchObject)
        {
            PageIndex = pageIndex;
            SearchObject = searchObject as TSearch;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
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

        public static PaginatedList<T, TSearch> Create(IEnumerable<T> source, int pageIndex, int pageSize, ISearchObject searchObject)
        {
            var count = source.Count();
            var items = source;
            return new PaginatedList<T, TSearch>(items, count, pageIndex, pageSize, searchObject);
        }
    }
}
