using Cat.Core.Extensions;
using Cat.IM.Core.Extensions;
using Cat.IM.Server.Controllers;
using Cat.IM.Server.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cat.IM.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCat();

            services.AddScoped<MessageController>();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["Redis:ConnectionString"];
                options.InstanceName = Configuration["Redis:InstanceName"];
            });

            services.AddReceiverMsg($"{Configuration["Service:IP"]}:{Configuration["Service:Port"]}");

            var heartBeatTime = Convert.ToInt32(Configuration["HeartBeatTime"]);
            var webSocket = Convert.ToBoolean(Configuration["WebSocket"]);

            if (webSocket)
            {
                services.AddWebIMServer(heartBeatTime);
            }
            else
            {
                services.AddIMServer(heartBeatTime);
            }
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseConsul(Configuration);
            app.UseMvc();
            app.UseCat();
        }
    }
}
