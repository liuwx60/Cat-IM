﻿using Cat.Cache.Manager;
using Cat.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Cache
{
    public class Startup : IStartup
    {
        public int Order => 0;

        public void Configure(IApplicationBuilder app)
        {
            //throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDistributedMemoryCache();

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = configuration["Redis:ConnectionString"];
            //    options.InstanceName = configuration["Redis:InstanceName"];
            //});

            services.AddSingleton<ICacheManager, RedisCacheManager>();
        }
    }
}
