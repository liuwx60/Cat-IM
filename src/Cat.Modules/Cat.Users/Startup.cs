using Cat.Core;
using Cat.Users.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users
{
    public class Startup : IStartup
    {
        public int Order => 2;

        public void Configure(IApplicationBuilder app)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
