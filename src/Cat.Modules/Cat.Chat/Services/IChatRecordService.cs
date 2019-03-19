using Cat.Chat.ViewModels.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Services
{
    public interface IChatRecordService
    {
        void Add(SendMessageInput input);
    }
}
