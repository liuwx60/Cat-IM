using Cat.Core;
using Cat.Core.Data;
using Cat.Core.Encrypts;
using Cat.Core.Paged;
using Cat.System.Models;
using Cat.System.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Cat.System.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(
            IRepository<Account> accountRepository
            )
        {
            _accountRepository = accountRepository;
        }

        public Account Login(AccountLoginInput input)
        {
            Assert.IfNullOrWhiteSpaceThrow(input.Username, "用户名不能为空");
            Assert.IfNullOrWhiteSpaceThrow(input.Password, "密码不能为空");

            var account = _accountRepository.Table.FirstOrDefault(x => x.Username == input.Username);

            Assert.IfNullThrow(account, "用户不存在");

            Assert.IfTrueThrow(input.Password.ToMD5() != account.Password, "密码错误");

            return account;
        }

        public PagedList<Account> List(FetchAccountsInput input)
        {
            var list = _accountRepository.Table;

            return new PagedList<Account>(list, input.PageInde, input.PageSize);
        }

        public void Add(Account input)
        {
            _accountRepository.Insert(input);
        }
    }
}
