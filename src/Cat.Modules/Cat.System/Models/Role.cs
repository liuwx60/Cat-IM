using Cat.Core;
using System;

namespace Cat.System.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }
    }
}
