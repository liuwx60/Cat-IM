using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.ViewModels.Api;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger
            )
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("/aa")]
        public IActionResult Aa()
        {
            var client = new ConsulClient(x => x.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}"));

            var service = client.Catalog.Service(_configuration["Service:Name"]).Result;

            return Ok(service.Response);
        }
    }
}
