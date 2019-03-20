using Cat.Authorization.Filter;
using Cat.Core;
using Cat.Core.Cache;
using Cat.IM.Google.Protobuf;
using Cat.Rabbit.Manage;
using Cat.Users.Models;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IRabbitManage _rabbitManage;
        private readonly IDistributedCache _cache;

        public FriendController(
            IFriendService friendService,
            IWorkContext workContext,
            IRabbitManage rabbitManage,
            IDistributedCache cache
            )
        {
            _friendService = friendService;
            _workContext = workContext;
            _rabbitManage = rabbitManage;
            _cache = cache;
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

                var message = new CatMessage
                {
                    Type = CatMessage.Types.MessageType.AddFriend,
                    Chat = new Chat
                    {
                        Sender = _workContext.CurrentUser.Id.ToString(),
                        Receiver = friendId.ToString(),
                        SendOn = DateTime.Now.ToString(),
                        Body = string.Empty
                    }
                };

                _rabbitManage.SendMsg(_cache.GetString($"{CacheKeys.ROUTER}{friendId}"), message);
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
