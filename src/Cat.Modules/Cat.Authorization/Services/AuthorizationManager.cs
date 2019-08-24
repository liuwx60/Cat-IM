using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cat.Authorization.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Authorization.Services
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IConfiguration _configuration;

        public AuthorizationManager(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        public UserTokenOutput UserToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var audienceConfig = _configuration.GetSection("Audience");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: audienceConfig["Issuer"],
                audience: audienceConfig["Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new UserTokenOutput { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
