using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.ViewModels.Api
{
    public class UserRecordInput
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
