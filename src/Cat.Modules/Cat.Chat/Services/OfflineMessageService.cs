using Cat.Chat.Models;
using Cat.Core.Data;
using Cat.Core.Paged;
using Cat.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Chat.Services
{
    public class OfflineMessageService : IOfflineMessageService
    {
        private readonly IRepository<OfflineMessage> _offlineMessageRepository;
        private readonly IWorkContext _workContext;

        public OfflineMessageService(
            IRepository<OfflineMessage> offlineMessageRepository,
            IWorkContext workContext
            )
        {
            _offlineMessageRepository = offlineMessageRepository;
            _workContext = workContext;
        }

        public IPagedList<OfflineMessage> PagedList()
        {
            var list = _offlineMessageRepository
                .Table
                .Where(x => x.Receiver == _workContext.CurrentUser.Id)
                .OrderBy(x => x.SendOn);

            var pagedList = new PagedList<OfflineMessage>(list, 0, 100);

            foreach (var item in pagedList)
            {
                _offlineMessageRepository.Delete(item);
            }

            return pagedList;
        }

        public void Add(OfflineMessage offlineMessage)
        {
            _offlineMessageRepository.Insert(offlineMessage);
        }
    }
}
