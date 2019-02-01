using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/a")]
        public IActionResult Index()
        {
            return Content("asd");
        }
    }
}
