using Cat.Core.Data;
using Cat.Users.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Cat.Users.Services
{
    public class WorkContext : IWorkContext
    {
        private User _user;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public WorkContext(
            IHttpContextAccessor httpContextAccessor, 
            IUserService userService
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public User CurrentUser
        {
            get
            {
                if (_user != null)
                {
                    return _user;
                }

                _user = _userService.Get(_httpContextAccessor.HttpContext.User.Identity.Name);

                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
