using Cat.Authorization.Filter;
using Cat.Cache.Manager;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("api/router")]
    public class RouterController : BaseApiController
    {
        private readonly ICacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly IConfiguration _configuration;

        public RouterController(
            ICacheManager cacheManager,
            IWorkContext workContext,
            IConfiguration configuration
            )
        {
            _cacheManager = cacheManager;
            _workContext = workContext;
            _configuration = configuration;
        }

        [HttpGet("get")]
        public ActionResult Get()
        {
            return Ok();
            //try
            //{
            //    var poll = Convert.ToInt32(await _cacheManager.GetStringAsync(CacheKeys.POLL));

            //    var client = new ConsulClient(x => x.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}"));

            //    var services = client.Catalog.Service(_configuration["Service:Name"]).Result.Response.ToList();

            //    if (services.Count < 1)
            //    {
            //        return BadRequest("获取不到服务器信息！");
            //    }

            //    var position = poll % services.Count;
            //    poll++;

            //    await _cacheManager.SetStringAsync(CacheKeys.POLL, poll.ToString());

            //    return Ok(new { services[position].ServiceAddress, services[position].ServicePort });
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RouterRegisterInput input)
        {
            await _cacheManager.SetStringAsync($"{CacheKeys.ROUTER}{_workContext.CurrentUser.Id}", input.Router);

            return Ok();
        }
    }
}
