using Cat.Authorization.Filter;
using Cat.Cache.Manage;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("api/router")]
    public class RouterController : BaseApiController
    {
        private readonly ICacheManage _cacheManage;
        private readonly IWorkContext _workContext;
        private readonly IConfiguration _configuration;

        public RouterController(
            ICacheManage cacheManage,
            IWorkContext workContext,
            IConfiguration configuration
            )
        {
            _cacheManage = cacheManage;
            _workContext = workContext;
            _configuration = configuration;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var client = new ConsulClient(x => x.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}"));

            var services = client.Catalog.Service(_configuration["Service:Name"]).Result.Response.ToList();

            return Ok(services);
        }

        [HttpPost("register")]
        public IActionResult Register(RouterRegisterInput input)
        {
            _cacheManage.SetString($"{CacheKeys.ROUTER}{_workContext.CurrentUser.Id}", input.Router);

            return Ok();
        }
    }
}
