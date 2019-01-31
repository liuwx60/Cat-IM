using Cat.Core;
using Cat.System.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.System
{
    public class Startup : IStartup
    {
        public int Order => 1;

        public void Configure(IApplicationBuilder app)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
