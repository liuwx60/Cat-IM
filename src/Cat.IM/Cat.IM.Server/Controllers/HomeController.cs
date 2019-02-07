using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Cat.IM.Google.Protobuf.ProtobufMessage.Types;

namespace Cat.IM.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/a")]
        public IActionResult Index()
        {
            return Content(MessageType.Chat.ToString());
        }

        [HttpGet("/aa")]
        public IActionResult Aa()
        {
            var client = new ConsulClient(x => x.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}"));

            var service = client.Catalog.Service(_configuration["Service:Name"]).Result;

            return Ok(service.Response);
        }

        public IActionResult SendMessage()
        {

            return Ok();
        }
    }
}
