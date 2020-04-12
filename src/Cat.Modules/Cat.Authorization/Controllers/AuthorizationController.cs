using Cat.Authorization.Filter;
using Cat.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cat.Authorization.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("api/authorization")]
    public class AuthorizationController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthorizationController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("permissions")]
        public IActionResult Permissions()
        {
            var permissions = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.GetName().Name.StartsWith("Cat"))
                .SelectMany(x => x.GetTypes())
                .Where(x => x.BaseType == typeof(BaseApiController))
                .ToDictionary(x => x.Name.Replace("Controller", ""), x => x.GetMethods().Where(o => o.DeclaringType == x && x.IsPublic).Select(o => o.Name).ToList());

            return Ok(permissions);
        }
    }
}
