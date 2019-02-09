using Cat.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.ViewModels.Api
{
    public class UserRecordOutput
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string NickName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
