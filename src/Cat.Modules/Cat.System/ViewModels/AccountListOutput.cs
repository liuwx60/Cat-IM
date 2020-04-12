using Cat.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.System.ViewModels
{
    public class AccountListOutput : BaseOutput
    {
        public string Username { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
