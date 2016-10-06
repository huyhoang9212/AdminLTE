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
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }
    }
}