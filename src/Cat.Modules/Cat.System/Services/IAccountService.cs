using Cat.Core;
using Cat.Core.Paged;
using Cat.System.Models;
using Cat.System.ViewModels;

namespace Cat.System.Services
{
    public interface IAccountService
    {
        Account Login(AccountLoginInput input);

        PagedList<Account> List(FetchAccountsInput input);

        void Add(Account input);
    }
}
