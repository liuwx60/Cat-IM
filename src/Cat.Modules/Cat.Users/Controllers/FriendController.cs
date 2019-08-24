using Cat.Authorization.Filter;
using Cat.Cache.Manager;
using Cat.Core;
using Cat.Core.Cache;
using Cat.IM.Google.Protobuf;
using Cat.Rabbit.Manager;
using Cat.Users.Models;
using Cat.Users.Services;
using Cat.Users.ViewModels.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cat.Users.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("/api/friend")]
    public class FriendController : BaseApiController
    {
        private readonly IFriendService _friendService;
        private readonly IWorkContext _workContext;
        private readonly IRabbitManager _rabbitManager;
        private readonly ICacheManager _cacheManager;

        public FriendController(
            IFriendService friendService,
            IWorkContext workContext,
            IRabbitManager rabbitManager,
            ICacheManager cacheManager
            )
        {
            _friendService = friendService;
            _workContext = workContext;
            _rabbitManager = rabbitManager;
            _cacheManager = cacheManager;
        }

        [HttpGet("get")]
        public ActionResult<IList<UserRecordOutput>> Get()
        {
            try
            {
                var list = _friendService.Get();

                return JsonMappingList<User, UserRecordOutput>(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add/{friendId}")]
        public async Task<IActionResult> Add(Guid friendId)
        {
            try
            {
                _friendService.Add(friendId);

                var message = new CatMessage
                {
                    Type = MessageType.AddFriend,
                    Base = new Base
                    {
                        Sender = _workContext.CurrentUser.Id.ToString(),
                        Receiver = friendId.ToString(),
                        SendOn = DateTime.Now.ToString(),
                    }
                };

                var router = await _cacheManager.GetStringAsync($"{CacheKeys.ROUTER}{friendId}");

                _rabbitManager.SendMsg(router, message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("black/{friendId}")]
        public ActionResult Black(Guid friendId)
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
        public ActionResult Delete(Guid friendId)
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
        public ActionResult Find(string username)
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
