using Cat.Authorization.Filter;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("api/router")]
    public class RouterController : BaseApiController
    {
        private readonly IDistributedCache _cache;
        private readonly IWorkContext _workContext;

        public RouterController(
            IDistributedCache cache,
            IWorkContext workContext
            )
        {
            _cache = cache;
            _workContext = workContext;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var str = _cache.GetString($"cat-router:{_workContext.CurrentUser.Id}");

            return Ok(str);
        }

        [HttpPost("register")]
        public IActionResult Register(RouterRegisterInput input)
        {
            _cache.SetStringAsync($"{CacheKeys.ROUTER}{_workContext.CurrentUser.Id}", input.Router);

            return Ok();
        }
    }
}
