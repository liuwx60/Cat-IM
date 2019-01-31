using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core.Paged
{
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        
        int PageSize { get; }
        
        int TotalCount { get; }
    }
}
