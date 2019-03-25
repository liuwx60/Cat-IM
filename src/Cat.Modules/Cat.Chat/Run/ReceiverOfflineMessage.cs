using Cat.Chat.Models;
using Cat.Chat.Services;
using Cat.Core.Data;
using Cat.Rabbit.Manage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Run
{
    public static class ReceiverOfflineMessage
    {
        public static void AddReceiverOfflineMessage(this IServiceCollection services)
        {
            var rabbitManage = services.BuildServiceProvider().GetService<IRabbitManage>();
            var offlineMessageService = services.BuildServiceProvider().GetService<IOfflineMessageService>();

            rabbitManage.Receiver("Cat.IM.OfflineMessage", x =>
            {
                var offlineMessage = new OfflineMessage
                {
                    Id = Guid.Parse(x.Chat.Id),
                    Body = x.Chat.Body,
                    Sender = Guid.Parse(x.Chat.Sender),
                    Receiver = Guid.Parse(x.Chat.Receiver),
                    SendOn = Convert.ToDateTime(x.Chat.SendOn),
                    Type = x.Type
                };

                offlineMessageService.Add(offlineMessage);

            }, "Cat.IM.OfflineMessage");
        }
    }
}
