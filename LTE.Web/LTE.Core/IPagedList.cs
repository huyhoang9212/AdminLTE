using System.Collections;
using System.Collections.Generic;

namespace LTE.Core
{
    public interface IPagedList<T> : IList<T>
    {
        int PageSize { get; }

        int CurrentPage { get;  }

        int TotalPages { get;  }

        int TotalItems { get;  }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        int FromPage { get; }

        int ToPage { get; }

        int CurrentRange { get; }

        int TotalRange { get; }

        int FromItem { get; }

        int ToItem { get; }
    }
}
