using Cat.Core;
using Cat.Core.Data;
using Cat.System.Models;

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

        public void Add(Account input)
        {
            _accountRepository.Insert(input);
        }
    }
}
