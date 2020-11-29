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
        public List<SelectListItem> genres { get; private set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize, List<SelectListItem> genres = null)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.genres = genres;
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

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize, List<SelectListItem> genres = null)
        {
            var count = source.Count();
            var items = source;
            return new PaginatedList<T>(items, count, pageIndex, pageSize, genres);
        }
    }
}
