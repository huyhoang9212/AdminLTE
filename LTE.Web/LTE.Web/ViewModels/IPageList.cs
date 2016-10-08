using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTE.Web.ViewModels
{
    public class PageList<T> where T : BaseViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int NumberOfPage { get; set; }

        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }




        public int TotalRange
        {
            get
            {
                return (int)Math.Ceiling((double)TotalPage / NumberOfPage);
            }
        }

        public int CurrentRange
        {
            get
            {
                return (int)Math.Ceiling((double)CurrentPage / NumberOfPage);
            }
        }

        public int FromPage
        {
            get
            {
                return (NumberOfPage * (CurrentRange - 1)) + 1;
            }
        }
        public int ToPage
        {
            get
            {
                return (NumberOfPage * CurrentRange) >= TotalPage ? TotalPage : (NumberOfPage * CurrentRange);
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

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        public bool HasNextPage
        { get { return CurrentPage < TotalPage; } }
    }
}