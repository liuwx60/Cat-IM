using Cat.Core.Data;
using Cat.Core.Extensions;
using Cat.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Web
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

            //services.AddDbContext<IDbContext, CatDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultContext")));

            services.AddDbContext<IDbContext, CatDbContext>(options =>
                options.UseSqlite("Data Source=MyTestDb.db"));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddCat();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();

            app.UseCat();
        }
    }
}
