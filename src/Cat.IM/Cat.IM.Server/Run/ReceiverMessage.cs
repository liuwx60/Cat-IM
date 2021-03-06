﻿using Cat.IM.Core;
using Cat.Rabbit.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.IM.Server.Run
{
    public class ReceiverMessage : IHostedService
    {
        private readonly ILogger<ReceiverMessage> _logger;
        private readonly IRabbitManager _rabbitManager;
        private readonly IConfiguration _configuration;

        public ReceiverMessage(
            ILogger<ReceiverMessage> logger, 
            IRabbitManager rabbitManager, 
            IConfiguration configuration
            )
        {
            _logger = logger;
            _rabbitManager = rabbitManager;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var routerKey = $"{_configuration["Service:IP"]}:{_configuration["Service:Port"]}";

            _rabbitManager.Receiver(routerKey, x =>
            {
                var context = SessionSocketHolder.Get(Guid.Parse(x.Chat.Info.Receiver));

                if (context == null)
                {
                    _logger.LogWarning($"用户[{x.Chat.Info.Receiver}]不在线！");

                    _rabbitManager.SendMsg("Cat.IM.OfflineMessage", x, "Cat.IM.OfflineMessage");

                    return;
                }

                context.WriteAndFlushAsync(x);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
