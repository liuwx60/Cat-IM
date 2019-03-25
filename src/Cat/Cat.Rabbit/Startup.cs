using Cat.Core;
using Cat.Rabbit.Manage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cat.Rabbit
{
    public class Startup : IStartup
    {
        public int Order => 3;

        public void Configure(IApplicationBuilder app)
        {
            //throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRabbitManage, RabbitManage>();
        }
    }
}
