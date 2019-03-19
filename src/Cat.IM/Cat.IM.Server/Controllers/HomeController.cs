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

        [HttpGet("/a")]
        public IActionResult Index()
        {
            return Content(CatMessage.Types.MessageType.Chat.ToString());
        }

        [HttpGet("/aa")]
        public IActionResult Aa()
        {
            var client = new ConsulClient(x => x.Address = new Uri($"http://{_configuration["Consul:IP"]}:{_configuration["Consul:Port"]}"));

            var service = client.Catalog.Service(_configuration["Service:Name"]).Result;

            return Ok(service.Response);
        }

        [HttpPost("/api/sendMessage")]
        public IActionResult SendMessage(SendMessageInput input)
        {
            var context = SessionSocketHolder.Get(input.Receiver);

            if (context == null)
            {
                _logger.LogWarning($"用户[{input.Receiver}]不在线！");

                return Ok();
            }

            var message = new CatMessage
            {
                Type = input.Type
            };

            if (message.Type == CatMessage.Types.MessageType.Chat)
            {
                message.Chat = new Chat
                {
                    Id = input.Id,
                    Sender = input.Sender.ToString(),
                    Receiver = input.Receiver.ToString(),
                    SendOn = input.SendOn.ToString(),
                    Body = input.Body
                };
            }

            context.WriteAndFlushAsync(message);

            return Ok();
        }
    }
}
