using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Services
{
    public interface IFriendService
    {
        void Add(Guid friendId);

        void Black(Guid friendId);

        void Delete(Guid friendId);
    }
}
