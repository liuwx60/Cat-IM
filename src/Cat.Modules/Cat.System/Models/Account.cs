using Cat.Core;
using System;

namespace Cat.System.Models
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }
    }
}
