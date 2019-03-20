using Cat.Core.Cache;
using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.ViewModels.Api;
using DotNetty.Buffers;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;

namespace Cat.IM.Server.Controllers
{
    public class MessageController : BaseMsgController
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;

        public MessageController(
            ILogger<MessageController> logger,
            IConfiguration configuration,
            IDistributedCache cache
            )
        {
            _logger = logger;
            _configuration = configuration;
            _cache = cache;
        }

        public void Login(Login input, IChannelHandlerContext context)
        {
            var client = new RestClient($"{_configuration["ApiUrl"]}/api/user/get");

            var request = new RestRequest(Method.GET)
                .AddHeader("Authorization", $"Bearer {input.Token}");

            var response = client.Execute<UserRecordInput>(request);

            if (!response.IsSuccessful)
            {
                context.CloseAsync();

                return;
            }

            context.SetUserId(response.Data.Id);

            _cache.SetStringAsync($"{CacheKeys.ROUTER}{response.Data.Id}", $"{_configuration["Service:IP"]}:{_configuration["Service:Port"]}");

            var a = _cache.GetString($"{CacheKeys.ROUTER}{response.Data.Id}");

            SessionSocketHolder.Add(response.Data.Id, context);
        }

        public void Ping(Ping input, IChannelHandlerContext context)
        {
            context.UpdateReaderTime(DateTime.Now);

            var message = new CatMessage
            {
                Type = CatMessage.Types.MessageType.Ping,
                Ping = new Ping
                {
                    Body = "pong"
                }
            };

            context.WriteAndFlushAsync(message);
        }

        public void HeartBeat(IChannelHandlerContext context)
        {
            var heartBeatTime = Convert.ToInt32(_configuration["HeartBeatTime"]);

            var lastReadTime = context.GetReaderTime();

            var now = DateTime.Now;

            if (lastReadTime != null && (now - lastReadTime).Value.Seconds > heartBeatTime)
            {
                _logger.LogInformation($"[{context.GetUserId()}]心跳超时");

                context.CloseAsync();
            }
        }
    }
}
