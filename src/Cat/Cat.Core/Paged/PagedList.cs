using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Core.Paged
{
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            TotalCount = source.Count();

            PageSize = pageSize;
            PageIndex = pageIndex;

            if (getOnlyTotalCount)
            {
                return;
            }

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count;
            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }
        
        public int PageIndex { get; }
        
        public int PageSize { get; }
        
        public int TotalCount { get; }
    }
}
