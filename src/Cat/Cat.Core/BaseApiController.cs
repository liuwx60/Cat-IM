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

        protected ActionResult BadRequest(string message)
        {
            return BadRequest(new { message });
        }
        
        protected JsonPagedList<T> JsonPagedList<T>(IPagedList<T> list)
        {
            return new JsonPagedList<T> { Rows = list, Total = list.TotalCount };
        }
        
        protected JsonPagedList<T> JsonPagedList<T>(IList<T> list, int totalItemCount)
        {
            return new JsonPagedList<T> { Rows = list, Total = totalItemCount };
        }

        protected JsonPagedList<M> JsonMappingPagedList<T, M>(IPagedList<T> list)
        {
            var mapperList = Mapper.Map<IList<T>, IList<M>>(list);
            return new JsonPagedList<M> { Rows = mapperList, Total = list.TotalCount };
        }

        protected JsonPagedList<M> JsonMappingPagedList<T, M>(IList<T> list, int totalItemCount)
        {
            var mapperList = Mapper.Map<IList<T>, IList<M>>(list);
            return new JsonPagedList<M> { Rows = mapperList, Total = totalItemCount };
        }

        protected List<M> JsonMappingList<T, M>(IList<T> list)
        {
            var mapperList = Mapper.Map<IList<T>, List<M>>(list);
            return mapperList;
        }

        protected M JsonObject<T, M>(T o)
        {
            return Mapper.Map<T, M>(o);
        }
    }
}
