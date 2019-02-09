using AutoMapper;
using Cat.Core.Paged;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Core
{
    public class BaseApiController : Controller
    {
        protected IMapper Mapper { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Mapper = context.HttpContext.RequestServices.GetService<IMapper>();

            base.OnActionExecuting(context);
        }

        protected IActionResult BadRequest(string message)
        {
            return BadRequest(new { message });
        }
        
        protected IActionResult JsonPagedList<T>(IPagedList<T> list)
        {
            return Ok(new { total = list.TotalCount, rows = list });
        }
        
        protected IActionResult JsonPagedList<T>(IList<T> list, int totalItemCount)
        {
            return Ok(new { total = totalItemCount, rows = list });
        }

        protected IActionResult JsonMappingPagedList<T, M>(IPagedList<T> list)
        {
            var mapperList = Mapper.Map<IList<T>, IList<M>>(list);
            return Ok(new { total = list.TotalCount, row = mapperList });
        }

        protected IActionResult JsonMappingPagedList<T, M>(IList<T> list, int totalItemCount)
        {
            var mapperList = Mapper.Map<IList<T>, IList<M>>(list);
            return Ok(new { total = totalItemCount, row = mapperList });
        }

        protected IActionResult JsonMappingList<T, M>(IList<T> list)
        {
            var mapperList = Mapper.Map<IList<T>, IList<M>>(list);
            return Ok(mapperList);
        }

        protected IActionResult JsonObject<T, M>(T o)
        {
            return Ok(Mapper.Map<T, M>(o));
        }
    }
}
