using Cat.Authorization.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Authorization.Services
{
    public interface IAuthorizationManager
    {
        UserTokenOutput UserToken(string username, string role = "Admin");
    }
}
