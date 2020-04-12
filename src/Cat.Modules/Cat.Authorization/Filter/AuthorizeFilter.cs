using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Authorization.Filter
{
    public class AuthorizeFilter : ActionFilterAttribute
    {
        public string Role { get; set; }

        public AuthorizeFilter(string role = "Admin")
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ignore = context.ActionDescriptor.EndpointMetadata
                .Select(x => x.GetType())
                .Any(x => x == typeof(AllowAnonymousAttribute));

            if (ignore)
            {
                return;
            }

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated || !user.IsInRole(Role))
            {
                context.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
