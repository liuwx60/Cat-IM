using Cat.Core.Extensions;
using Cat.IM.Server.Controllers;
using Cat.IM.Server.Run;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddControllersWithViews();

            services.AddCat();

            services.AddSingleton<MessageController>();

            services.AddHostedService<CatIMServer>();
            services.AddHostedService<ReceiverMessage>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCat();
        }
    }
}
