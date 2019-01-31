using Cat.Core;
using Cat.System.Models;
using Cat.System.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.System.Controllers
{
    [Controller]
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("api/admin/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
