using Cat.Authorization.Filter;
using Cat.Authorization.Services;
using Cat.Authorization.ViewModels;
using Cat.Core;
using Cat.Users.Models;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationManage _authorizationManage;
        private readonly IWorkContext _workContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(
            IUserService userService,
            IAuthorizationManage authorizationManage,
            IWorkContext workContext,
            IHostingEnvironment hostingEnvironment
            )
        {
            _userService = userService;
            _authorizationManage = authorizationManage;
            _workContext = workContext;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [HttpPost("api/user/register")]
        public IActionResult Register(RegisterInput input)
        {
            try
            {
                _userService.Register(input);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("api/user/login")]
        public IActionResult Login(LoginInput input)
        {
            UserTokenOutput output = null;

            try
            {
                var user = _userService.Login(input);

                output = _authorizationManage.UserToken(user.Username);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok(output);
        }
        
        [HttpGet("api/user/get")]
        public IActionResult Get()
        {
            var user = _workContext.CurrentUser;

            return JsonObject<User, UserRecordOutput>(user);
        }

        [HttpPut("api/user/edit")]
        public IActionResult Edit(UserRecordInput input)
        {
            try
            {
                input.Id = _workContext.CurrentUser.Id;

                _userService.Update(input);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("api/user/upload/avatar")]
        public IActionResult UploadAvatar(IFormFile file)
        {
            try
            {
                var virtualPath = $"/upload/avatar/";

                var filePath = $"{_hostingEnvironment.WebRootPath}{virtualPath}";

                var exts = new List<string>
                {
                    ".jpg",
                    ".png"
                };

                if (!exts.Contains(Path.GetExtension(file.FileName).ToLower()))
                {
                    return BadRequest("只支持上传文件格式：" + string.Join(",", exts));
                }

                if (file.Length > 0)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }

                    string fileName = $"{_workContext.CurrentUser.Id}.jpg";

                    using (var stream = new FileStream($"{filePath}{fileName}", FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("api/user/avatar/{id}")]
        public IActionResult Avatar(Guid id)
        {
            if (!System.IO.File.Exists($"{_hostingEnvironment.WebRootPath}/upload/avatar/{id}.jpg"))
            {
                return File("/avatar.jpg", "image/jpeg");
            }

            return File($"/upload/avatar/{id}.jpg", "image/jpeg");
        }
    }
}
