using Cat.Authorization.Filter;
using Cat.Core;
using Cat.Core.Encrypts;
using Cat.File.ViewModels.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cat.File.Controllers
{
    //[AuthorizeFilter]
    [ApiController]
    [Route("/api/upload")]
    public class UploadController : BaseApiController
    {
        private static List<string> ImageExts = new List<string> { ".jpg", ".png", ".gif" };

        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("image")]
        public ActionResult Image(IFormFile file)
        {
            try
            {
                if (file.Length <= 0)
                {
                    return BadRequest("请选择要上传的文件！");
                }

                var md5 = string.Empty;

                using (var stream = file.OpenReadStream())
                {
                    md5 = stream.ToMD5().ToLower();
                }

                var virtualPath = $"/upload/file/{md5[0]}/{md5[1]}/{md5[2]}/";

                var filePath = $"{_hostingEnvironment.WebRootPath}{virtualPath}";

                var ext = Path.GetExtension(file.FileName).ToLower();

                if (!ImageExts.Contains(ext))
                {
                    return BadRequest("只支持上传文件格式：" + string.Join(",", ImageExts));
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                
                var fileName = $"{md5}{ext}";

                var fullFilePath = $"{filePath}{fileName}";

                if (System.IO.File.Exists(fullFilePath))
                {
                    return Ok();
                }

                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("exists")]
        public ActionResult<FileExistsOutput> Exists(FileExistsInput input)
        {
            try
            {
                var virtualPath = $"/upload/file/{input.FileName[0]}/{input.FileName[1]}/{input.FileName[2]}/";

                var filePath = $"{_hostingEnvironment.WebRootPath}{virtualPath}";

                var fullFilePath = $"{filePath}{input.FileName}";

                return new FileExistsOutput { Exists = System.IO.File.Exists(fullFilePath) };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
