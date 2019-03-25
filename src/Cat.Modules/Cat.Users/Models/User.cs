using Cat.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string NickName { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        public string Email { get; set; }

        public string Mobile { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime OfflineOn { get; set; } = DateTime.Now;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
