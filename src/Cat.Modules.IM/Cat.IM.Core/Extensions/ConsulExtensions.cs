using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace Cat.IM.Core.Extensions
{
    public static class ConsulExtensions
    {
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            //var client = new ConsulClient(x => x.Address = new Uri($"http://{configuration["Consul:IP"]}:{configuration["Consul:Port"]}"));

            //client.Agent.ServiceRegister(new AgentServiceRegistration
            //{
            //    ID = $"{configuration["Service:Name"]}_{configuration["Service:Port"]}",
            //    Name = configuration["Service:Name"],
            //    Address = configuration["Service:IP"],
            //    Port = Convert.ToInt32(configuration["Service:Port"]),
            //    Tags = new[] { $"urlprefix-/{configuration["Service:Name"]}-{configuration["Service:IP"]}:{configuration["Service:Port"]}" },
            //    //Check = new AgentServiceCheck
            //    //{
            //    //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(15),
            //    //    Interval = TimeSpan.FromSeconds(10),
            //    //    HTTP = $"http://{configuration["Service:IP"]}:{configuration["Service:Port"]}/api/health",
            //    //    Timeout = TimeSpan.FromSeconds(5)
            //    //}
            //}).Wait();

            return app;
        }
    }
}
