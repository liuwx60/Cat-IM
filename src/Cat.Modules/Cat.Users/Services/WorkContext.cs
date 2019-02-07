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
        private readonly IRepository<User> _userRepository;

        public WorkContext(
            IHttpContextAccessor httpContextAccessor, 
            IRepository<User> userRepository
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public User CurrentUser
        {
            get
            {
                if (_user != null)
                {
                    return _user;
                }

                _user = _userRepository.Table.FirstOrDefault(x => x.Username == _httpContextAccessor.HttpContext.User.Identity.Name);

                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
