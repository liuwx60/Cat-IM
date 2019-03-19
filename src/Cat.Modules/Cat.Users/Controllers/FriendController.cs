using Cat.Authorization.Filter;
using Cat.Chat.Services;
using Cat.Chat.ViewModels.Api;
using Cat.Core;
using Cat.Users.Models;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
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
        private readonly IWorkContext _workContext;
        private readonly IChatService _chatService;

        public FriendController(
            IFriendService friendService,
            IWorkContext workContext,
            IChatService chatService
            )
        {
            _friendService = friendService;
            _workContext = workContext;
            _chatService = chatService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var list = _friendService.Get();

            return JsonMappingList<User, UserRecordOutput>(list);
        }

        [HttpPost("add/{friendId}")]
        public IActionResult Add(Guid friendId)
        {
            try
            {
                _friendService.Add(friendId);

                var input = new SendMessageInput
                {
                    Sender = _workContext.CurrentUser.Id,
                    Receiver = friendId,
                    SendOn = DateTime.Now,
                    Type = IM.Google.Protobuf.CatMessage.Types.MessageType.AddFriend
                };

                _chatService.SendMsg(input);
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

        [HttpGet("find/{username}")]
        public IActionResult Find(string username)
        {
            FriendFindOutput output = null;

            try
            {
                output = _friendService.Find(username);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(output);
        }
    }
}
