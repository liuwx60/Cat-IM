using System;
using Cat.Core;

namespace Cat.Authorization.Models
{
    public class Permission : BaseEntity
    {
        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }
    }
}