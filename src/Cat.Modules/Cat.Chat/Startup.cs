using Cat.Chat.Run;
using Cat.Chat.Services;
using Cat.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Chat
{
    public class Startup : IStartup
    {
        public int Order => 0;

        public void Configure(IApplicationBuilder app)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IChatRecordService, ChatRecordService>();
            services.AddSingleton<IChatService, ChatService>();
            services.AddScoped<IOfflineMessageService, OfflineMessageService>();
            services.AddHostedService<ReceiverOfflineMessage>();
        }
    }
}
