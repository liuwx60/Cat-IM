using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Services
{
    public interface IChatService
    {
        void SendMsg(object input);
    }
}
