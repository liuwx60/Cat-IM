using Cat.Authorization.Filter;
using Cat.Cache.Manager;
using Cat.Chat.Models;
using Cat.Chat.Services;
using Cat.Chat.ViewModels.Api;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Core.Paged;
using Cat.IM.Google.Protobuf;
using Cat.Rabbit.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cat.Chat.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("/api/chat")]
    public class ChatController : BaseApiController
    {
        private readonly IChatRecordService _chatRecordService;
        private readonly IRabbitManager _rabbitManager;
        private readonly ICacheManager _cacheManager;
        private readonly IOfflineMessageService _offlineMessageService;

        public ChatController(
            IChatRecordService chatRecordService,
            IRabbitManager rabbitManager,
            ICacheManager cacheManager,
            IOfflineMessageService offlineMessageService
            )
        {
            _chatRecordService = chatRecordService;
            _rabbitManager = rabbitManager;
            _cacheManager = cacheManager;
            _offlineMessageService = offlineMessageService;
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMsg(SendMessageInput input)
        {
            try
            {
                var message = new CatMessage
                {
                    Type = input.Type,
                    Chat = new IM.Google.Protobuf.Chat
                    {
                        Info = new Base
                        {
                            Id = input.Id.ToString(),
                            Sender = input.Sender.ToString(),
                            Receiver = input.Receiver.ToString(),
                            SendOn = input.SendOn.ToString(),
                        },
                        Body = input.Body
                    }
                };

                var routeKey = await _cacheManager.GetStringAsync($"{CacheKeys.ROUTER}{input.Receiver}");

                if (string.IsNullOrWhiteSpace(routeKey))
                {
                    _rabbitManager.SendMsg("Cat.IM.OfflineMessage", message, "Cat.IM.OfflineMessage");
                }
                else
                {
                    _rabbitManager.SendMsg(routeKey, message);
                }
                

                _chatRecordService.Add(input);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("offlineMessage")]
        public ActionResult<JsonPagedList<OfflineMessage>> OfflineMessage()
        {
            try
            {
                var pageList = _offlineMessageService.PagedList();

                return JsonPagedList(pageList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
