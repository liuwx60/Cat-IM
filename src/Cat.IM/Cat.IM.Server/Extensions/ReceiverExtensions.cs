using Cat.IM.Core;
using Cat.Rabbit.Manage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Extensions
{
    public static class ReceiverExtensions
    {
        public static IServiceCollection AddReceiverMsg(this IServiceCollection services, string routeKey)
        {
            var rabbitManage = services.BuildServiceProvider().GetService<IRabbitManage>();
            var logger = services.BuildServiceProvider().GetService<ILogger<IRabbitManage>>();

            rabbitManage.Receiver(routeKey, x =>
            {
                logger.LogInformation($"收到消息：{x.ToString()}");

                var context = SessionSocketHolder.Get(Guid.Parse(x.Chat.Receiver));

                if (context == null)
                {
                    logger.LogWarning($"用户[{x.Chat.Receiver}]不在线！");

                    return;
                }

                context.WriteAndFlushAsync(x);
            });

            return services;
        }
    }
}
