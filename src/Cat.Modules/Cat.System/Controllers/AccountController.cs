using Cat.Authorization.Filter;
using Cat.Authorization.Services;
using Cat.Authorization.ViewModels;
using Cat.Core;
using Cat.Core.Paged;
using Cat.System.Models;
using Cat.System.Services;
using Cat.System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.System.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly IAccountService _accountService;

        public AccountController(IAuthorizationManager authorizationManager, IAccountService accountService)
        {
            _authorizationManager = authorizationManager;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<UserTokenOutput> Login(AccountLoginInput input)
        {
            UserTokenOutput output = null;

            try
            {
                var user = _accountService.Login(input);

                output = _authorizationManager.UserToken(user.Username);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return output;
        }

        [HttpGet("fetch")]
        public ActionResult<JsonPagedList<AccountListOutput>> Fetch([FromQuery] FetchAccountsInput input)
        {
            var list = _accountService.List(input);

            return JsonMappingPagedList<Account, AccountListOutput>(list);
        }

        [HttpGet("init")]
        [AllowAnonymous]
        public ActionResult Init()
        {
            _accountService.Add(new Account
            {
                Username = "admin",
                Password = "qwe123"
            });

            return Ok();
        }
    }
}
