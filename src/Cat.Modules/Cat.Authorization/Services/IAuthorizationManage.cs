using Cat.Authorization.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Authorization.Services
{
    public interface IAuthorizationManage
    {
        UserTokenOutput UserToken(string username);
    }
}
