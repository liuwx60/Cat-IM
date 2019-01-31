using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core.Paged
{
    public class PagerParameters
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int PageInde => Page <= 0 ? 0 : Page - 1;
    }
}
