using Cat.Authorization.Filter;
using Cat.Authorization.Services;
using Cat.Authorization.ViewModels;
using Cat.Core;
using Cat.Users.Models;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationManage _authorizationManage;
        private readonly IWorkContext _workContext;

        public UserController(
            IUserService userService,
            IAuthorizationManage authorizationManage,
            IWorkContext workContext
            )
        {
            _userService = userService;
            _authorizationManage = authorizationManage;
            _workContext = workContext;
        }

        [AllowAnonymous]
        [HttpPost("api/user/register")]
        public IActionResult Register(RegisterInput input)
        {
            try
            {
                _userService.Register(input);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("api/user/login")]
        public IActionResult Login(LoginInput input)
        {
            UserTokenOutput output = null;

            try
            {
                var user = _userService.Login(input);

                output = _authorizationManage.UserToken(user.Username);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok(output);
        }
        
        [HttpPost("api/user/get")]
        public IActionResult Get()
        {
            var user = _workContext.CurrentUser;

            return JsonObject<User, UserRecordOutput>(user);
        }
    }
}
