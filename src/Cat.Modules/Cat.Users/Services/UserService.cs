using Cat.Cache.Manager;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Core.Data;
using Cat.Core.Encrypts;
using Cat.Users.Models;
using Cat.Users.ViewModels.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ICacheManager _cacheManager;

        public UserService(
            IRepository<User> userRepository,
            ICacheManager cacheManager
            )
        {
            _userRepository = userRepository;
            _cacheManager = cacheManager;
        }

        public void Register(RegisterInput input)
        {
            Assert.IfNullOrWhiteSpaceThrow(input.Username, "用户名不能为空");
            Assert.IfTrueThrow(input.Username.Length < 6, "用户名不能少于6位");
            Assert.IfNullOrWhiteSpaceThrow(input.Password1, "密码不能为空");
            Assert.IfNullOrWhiteSpaceThrow(input.Password2, "密码不能为空");
            Assert.IfTrueThrow(input.Password1 != input.Password2, "密码不一致");
            Assert.IfTrueThrow(_userRepository.Table.Any(x => x.Username == input.Username), "用户名已存在");

            var user = new User
            {
                Username = input.Username,
                Password = input.Password1.ToMD5(),
                NickName = $"Cat_{Guid.NewGuid().ToString().Substring(0, 8)}"
            };

            _userRepository.Insert(user);
        }

        public User Login(LoginInput input)
        {
            Assert.IfNullOrWhiteSpaceThrow(input.Username, "用户名不能为空");
            Assert.IfNullOrWhiteSpaceThrow(input.Password, "密码不能为空");

            var user = _userRepository.Table.FirstOrDefault(x => x.Username == input.Username);

            Assert.IfNullThrow(user, "用户不存在");

            Assert.IfTrueThrow(input.Password.ToMD5() != user.Password, "密码错误");

            return user;
        }

        public User Get(string username)
        {
            var user = _cacheManager.GetAsync($"{CacheKeys.USER}{username}", () =>
            {
                var query = _userRepository.Table.FirstOrDefault(x => x.Username == username);

                Assert.IfNullThrow(query, "用户不存在");

                return query;
            }).Result;

            Assert.IfNullThrow(user, "用户不存在");

            return user;
        }

        public void ChangePassword(ChangePasswordInput input)
        {
            Assert.IfNullOrWhiteSpaceThrow(input.Password1, "密码不能为空");
            Assert.IfNullOrWhiteSpaceThrow(input.Password2, "密码不能为空");
            Assert.IfTrueThrow(input.Password1 != input.Password2, "密码不一致");

            var user = _userRepository.GetById(input.Id);

            Assert.IfNullThrow(user, "用户不存在");

            user.Password = input.Password1.ToMD5();

            _userRepository.Update(user);
        }

        public void Update(UserRecordInput input)
        {
            var user = _userRepository.GetById(input.Id);

            Assert.IfNullThrow(user, "用户不存在！");

            user.NickName = input.NickName;
            user.Gender = input.Gender;

            _userRepository.Update(user);
        }

        public void Offline(Guid id)
        {
            var user = _userRepository.GetById(id);

            Assert.IfNullThrow(user, "用户不存在！");

            user.OfflineOn = DateTime.Now;

            _userRepository.Update(user);

            _cacheManager.RemoveAsync($"{CacheKeys.ROUTER}{id}").Wait();
        }
    }
}
