using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.ViewModels.Api
{
    public class RegisterInput
    {
        public string Username { get; set; }

        public string Password1 { get; set; }

        public string Password2 { get; set; }
    }
}
