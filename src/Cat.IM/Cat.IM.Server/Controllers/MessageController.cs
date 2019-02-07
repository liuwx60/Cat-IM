using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.ViewModels.Api;
using DotNetty.Transport.Channels;
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

        public MessageController(
            ILogger<MessageController> logger,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Login(Login input, IChannelHandlerContext context)
        {
            var client = new RestClient($"{_configuration["ApiUrl"]}/api/user/get");

            var request = new RestRequest(Method.POST)
                .AddHeader("Authorization", $"Bearer {input.Token}");

            var response = client.Execute<UserRecordInput>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                context.CloseAsync();

                return;
            }

            context.SetUserId(response.Data.Id);

            SessionSocketHolder.Add(response.Data.Id, context);
        }

        public void Ping(Ping input, IChannelHandlerContext context)
        {
            context.UpdateReaderTime(DateTime.Now);
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
