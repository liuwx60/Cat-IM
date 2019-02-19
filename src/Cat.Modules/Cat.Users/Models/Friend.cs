using Cat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Models
{
    public class Friend : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid FriendId { get; set; }

        public bool Blacked { get; set; } = false;

        public DateTime CreateOn { get; set; } = DateTime.Now;

        public DateTime UpdateOn { get; set; } = DateTime.Now;
    }
}
