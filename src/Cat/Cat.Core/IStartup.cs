using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core
{
    public interface IStartup
    {
        int Order { get; }

        void ConfigureServices(IServiceCollection services);

        void Configure(IApplicationBuilder app);
    }
}
