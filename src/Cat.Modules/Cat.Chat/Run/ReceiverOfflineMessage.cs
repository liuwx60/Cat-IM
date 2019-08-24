using Cat.Chat.Models;
using Cat.Chat.Services;
using Cat.Core.Data;
using Cat.Rabbit.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Chat.Run
{
    public class ReceiverOfflineMessage : IHostedService
    {
        private readonly IRabbitManager _rabbitManager;
        private readonly IServiceProvider _serviceProvider;
        private IOfflineMessageService _offlineMessageService;

        public ReceiverOfflineMessage(
            IRabbitManager rabbitManager,
            IServiceProvider serviceProvider
            )
        {
            _rabbitManager = rabbitManager;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _offlineMessageService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IOfflineMessageService>();

            _rabbitManager.Receiver("Cat.IM.OfflineMessage", x =>
            {
                var offlineMessage = new OfflineMessage
                {
                    Id = Guid.Parse(x.Chat.Info.Id),
                    Body = x.Chat.Body,
                    Sender = Guid.Parse(x.Chat.Info.Sender),
                    Receiver = Guid.Parse(x.Chat.Info.Receiver),
                    SendOn = Convert.ToDateTime(x.Chat.Info.SendOn),
                    Type = x.Type
                };

                _offlineMessageService.Add(offlineMessage);

            }, "Cat.IM.OfflineMessage");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
