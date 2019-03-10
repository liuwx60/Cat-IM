using Cat.Users.Models;
using Cat.Users.ViewModels.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Services
{
    public interface IFriendService
    {
        IList<User> Get();

        void Add(Guid friendId);

        void Black(Guid friendId);

        void Delete(Guid friendId);

        FriendFindOutput Find(string username);
    }
}
