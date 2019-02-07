using Cat.Users.Models;
using Cat.Users.ViewModels.Api;

namespace Cat.Users.Services
{
    public interface IUserService
    {
        void Register(RegisterInput input);

        User Login(LoginInput input);

        User Get(string username);

        void ChangePassword(ChangePasswordInput input);
    }
}
