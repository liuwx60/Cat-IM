using AutoMapper;
using Cat.Core.Data;
using Cat.Core.Extensions;
using Cat.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

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
            services.AddCors(options =>
            {
                options.AddPolicy("cors", x =>
                {
                    x.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>> { { "Cat.Web", new string[] { } }, };
                c.AddSecurityRequirement(security);

                c.AddSecurityDefinition("Cat.Web", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header"
                });
            });

            services.AddHttpContextAccessor();

            services.AddDbContext<IDbContext, CatDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlContext")));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddCat();

            services.AddAutoMapper();
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

            app.UseCors("cors");
            app.UseStaticFiles();
            app.UseCat();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
