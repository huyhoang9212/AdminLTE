using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


namespace LTE.Core
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> query, int currentePage, int pageSize)
        {
            int totalItems = query.Count();
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            CurrentPage = currentePage;
            PageSize = pageSize;
            this.AddRange(query.Skip((currentePage - 1) * pageSize).Take(pageSize).ToList());

            NumberPagesPerRange = 5;
        }

        public PagedList(IEnumerable<T> list, int currentPage, int pageSize, int totalItems)
        {
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            CurrentPage = currentPage;
            PageSize = pageSize;
            this.AddRange(list);
            NumberPagesPerRange = 5;
        }


        public int CurrentPage
        {
            get; private set;
        }

        public int PageSize
        {
            get; private set;
        }

        public int TotalItems
        {
            get; private set;
        }

        public int TotalPages
        {
            get; private set;
        }

        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
        }

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        #region Support page range
        public int NumberPagesPerRange { get; private set; }

        public int CurrentRange
        {
            get
            {
                return (int)Math.Ceiling((double)CurrentPage / NumberPagesPerRange);
            }
        }

        public int TotalRange
        {
            get
            {
                return (int)Math.Ceiling((double)TotalPages / NumberPagesPerRange);
            }
        }

        public int FromPage
        {
            get
            {
                return (NumberPagesPerRange * (CurrentRange - 1)) + 1;
            }
        }

        public int ToPage
        {
            get
            {
                return (NumberPagesPerRange * CurrentRange) >= TotalPages ? TotalPages : (NumberPagesPerRange * CurrentRange);
            }
        }

        public int FromItem
        {
            get { return ((CurrentPage - 1) * PageSize + 1); }
        }
        public int ToItem
        {
            get { return CurrentPage * PageSize >= TotalItems ? TotalItems : CurrentPage * PageSize; }
        }
        #endregion
    }
}
