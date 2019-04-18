using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core.Paged
{
    public class JsonPagedList<T>
    {
        public IList<T> Rows { get; set; }

        public int Total { get; set; }
    }
}
