using Cat.Authorization.Filter;
using Cat.Cache.Manage;
using Cat.Chat.Models;
using Cat.Chat.Services;
using Cat.Chat.ViewModels.Api;
using Cat.Core;
using Cat.Core.Cache;
using Cat.Core.Paged;
using Cat.IM.Google.Protobuf;
using Cat.Rabbit.Manage;
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
        private readonly IRabbitManage _rabbitManage;
        private readonly ICacheManage _cacheManage;
        private readonly IOfflineMessageService _offlineMessageService;

        public ChatController(
            IChatRecordService chatRecordService,
            IRabbitManage rabbitManage,
            ICacheManage cacheManage,
            IOfflineMessageService offlineMessageService
            )
        {
            _chatRecordService = chatRecordService;
            _rabbitManage = rabbitManage;
            _cacheManage = cacheManage;
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
                        Id = input.Id.ToString(),
                        Body = input.Body,
                        Sender = input.Sender.ToString(),
                        Receiver = input.Receiver.ToString(),
                        SendOn = input.SendOn.ToString(),
                    }
                };

                var routeKey = await _cacheManage.GetStringAsync($"{CacheKeys.ROUTER}{input.Receiver}");

                if (string.IsNullOrWhiteSpace(routeKey))
                {
                    _rabbitManage.SendMsg("Cat.IM.OfflineMessage", message, "Cat.IM.OfflineMessage");
                }
                else
                {
                    _rabbitManage.SendMsg(routeKey, message);
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
