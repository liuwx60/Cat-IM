using Cat.IM.Core;
using Cat.Rabbit.Manage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Run
{
    public class ReceiverMessage : IStartupFilter
    {
        private readonly ILogger<ReceiverMessage> _logger;
        private readonly IRabbitManage _rabbitManage;
        private readonly IConfiguration _configuration;

        public ReceiverMessage(
            ILogger<ReceiverMessage> logger, 
            IRabbitManage rabbitManage, 
            IConfiguration configuration
            )
        {
            _logger = logger;
            _rabbitManage = rabbitManage;
            _configuration = configuration;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            var routerKey = $"{_configuration["Service:IP"]}:{_configuration["Service:Port"]}";

            _rabbitManage.Receiver(routerKey, x =>
            {
                var context = SessionSocketHolder.Get(Guid.Parse(x.Chat.Receiver));

                if (context == null)
                {
                    _logger.LogWarning($"用户[{x.Chat.Receiver}]不在线！");

                    _rabbitManage.SendMsg("Cat.IM.OfflineMessage", x, "Cat.IM.OfflineMessage");

                    return;
                }

                context.WriteAndFlushAsync(x);
            });

            return next;
        }
    }
}
