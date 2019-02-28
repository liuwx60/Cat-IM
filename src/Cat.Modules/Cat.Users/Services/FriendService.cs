﻿using Cat.Core;
using Cat.Core.Data;
using Cat.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Users.Services
{
    public class FriendService : IFriendService
    {
        private readonly IRepository<Friend> _friendRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepository<User> _userRepository;

        public FriendService(
            IRepository<Friend> friendRepository, 
            IWorkContext workContext,
            IRepository<User> userRepository
            )
        {
            _friendRepository = friendRepository;
            _workContext = workContext;
            _userRepository = userRepository;
        }

        public IList<User> Get()
        {
            var friendIds = _friendRepository
                .Table
                .Where(x => x.UserId == _workContext.CurrentUser.Id)
                .Select(x => x.FriendId)
                .Union(
                    _friendRepository
                    .Table
                    .Where(x => x.FriendId == _workContext.CurrentUser.Id)
                    .Select(x => x.UserId)
                );

            var users = _userRepository
                .Table
                .Where(x => friendIds.Contains(x.Id))
                .ToList();

            return users;
        }

        public void Add(Guid friendId)
        {
            var friend = _friendRepository
                .Table
                .FirstOrDefault(x => 
                    (x.UserId == _workContext.CurrentUser.Id && x.FriendId == friendId)
                    || (x.UserId == friendId && x.FriendId == _workContext.CurrentUser.Id));

            Assert.IfTrueThrow(friend != null, "已是好友关系，无法重复添加！");
            
            _friendRepository.Insert(new Friend
            {
                UserId = _workContext.CurrentUser.Id,
                FriendId = friendId
            });
        }

        public void Black(Guid friendId)
        {
            var friend = _friendRepository
                .Table
                .FirstOrDefault(x =>
                    (x.UserId == _workContext.CurrentUser.Id && x.FriendId == friendId)
                    || (x.UserId == friendId && x.FriendId == _workContext.CurrentUser.Id));

            Assert.IfNullThrow(friend, "对方不是您的好友，无法拉入黑名单！");

            friend.Blacked = true;
            friend.UpdateOn = DateTime.Now;

            _friendRepository.Update(friend);
        }

        public void Delete(Guid friendId)
        {
            var friend = _friendRepository
                .Table
                .FirstOrDefault(x =>
                    (x.UserId == _workContext.CurrentUser.Id && x.FriendId == friendId)
                    || (x.UserId == friendId && x.FriendId == _workContext.CurrentUser.Id));

            Assert.IfNullThrow(friend, "对方不是您的好友，无法删除！");

            _friendRepository.Delete(friend);
        }
    }
}
