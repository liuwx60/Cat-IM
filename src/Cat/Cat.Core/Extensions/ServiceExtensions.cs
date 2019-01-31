using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Cat.Core.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCat(this IServiceCollection services)
        {
            var interfaceImplements = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().Contains(typeof(IStartup)))
                .Select(x => (IStartup)Activator.CreateInstance(x))
                .OrderByDescending(x => x.Order);

            foreach (var startup in interfaceImplements)
            {
                startup.ConfigureServices(services);
            }

            return services;
        }
    }
}
