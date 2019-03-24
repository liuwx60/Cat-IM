using Cat.Core.Extensions;
using Cat.IM.Core.Extensions;
using Cat.IM.Server.Controllers;
using Cat.IM.Server.Run;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCat();

            services.AddSingleton<MessageController>();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["Redis:ConnectionString"];
                options.InstanceName = Configuration["Redis:InstanceName"];
            });

            services.AddSingleton<IStartupFilter, ReceiverMessage>();
            services.AddSingleton<IStartupFilter, CatIMServer>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseConsul(Configuration);
            app.UseMvc();
            app.UseCat();
        }
    }
}
