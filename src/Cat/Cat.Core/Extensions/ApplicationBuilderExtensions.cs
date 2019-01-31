using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCat(this IApplicationBuilder app)
        {
            var interfaceImplements = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().Contains(typeof(IStartup)))
                .Select(x => (IStartup)Activator.CreateInstance(x))
                .OrderByDescending(x => x.Order);

            foreach (var startup in interfaceImplements)
            {
                startup.Configure(app);
            }

            return app;
        }
    }
}
