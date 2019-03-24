using Cat.Chat.Models;
using Cat.Core.Paged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Services
{
    public interface IOfflineMessageService
    {
        IPagedList<OfflineMessage> PagedList();

        void Add(OfflineMessage offlineMessage);
    }
}
