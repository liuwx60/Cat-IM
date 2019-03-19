using Cat.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.ViewModels.Api
{
    public class FriendFindOutput
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public string Username { get; set; }

        public Gender Gender { get; set; }

        public bool IsFriend { get; set; }
    }
}
