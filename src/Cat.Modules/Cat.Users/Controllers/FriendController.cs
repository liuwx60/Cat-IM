using Cat.Authorization.Filter;
using Cat.Core;
using Cat.Users.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("/api/friend")]
    public class FriendController : BaseApiController
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost("add/{friendId}")]
        public IActionResult Add(Guid friendId)
        {
            try
            {
                _friendService.Add(friendId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("black/{friendId}")]
        public IActionResult Black(Guid friendId)
        {
            try
            {
                _friendService.Black(friendId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("delete/{friendId}")]
        public IActionResult Delete(Guid friendId)
        {
            try
            {
                _friendService.Delete(friendId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
