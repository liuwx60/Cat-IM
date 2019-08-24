using Cat.Authorization.Services;
using Cat.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Authorization
{
    public class Startup : IStartup
    {
        public int Order => 99;

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationManager, AuthorizationManager>();

            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var audienceConfig = configuration.GetSection("Audience");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = audienceConfig["Issuer"],

                        ValidateAudience = true,
                        ValidAudience = audienceConfig["Audience"],

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"])),

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
