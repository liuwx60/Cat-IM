using Cat.Authorization.Filter;
using Cat.Chat.Services;
using Cat.Chat.ViewModels.Api;
using Cat.Core;
using Cat.Core.Cache;
using Cat.IM.Google.Protobuf;
using Cat.Rabbit.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Controllers
{
    [AuthorizeFilter]
    [ApiController]
    [Route("/api/chat")]
    public class ChatController : BaseApiController
    {
        private readonly IChatRecordService _chatRecordService;
        private readonly IRabbitManage _rabbitManage;
        private readonly IDistributedCache _cache;

        public ChatController(
            IChatRecordService chatRecordService,
            IRabbitManage rabbitManage,
            IDistributedCache cache
            )
        {
            _chatRecordService = chatRecordService;
            _rabbitManage = rabbitManage;
            _cache = cache;
        }

        [HttpPost("sendMessage")]
        public IActionResult SendMsg(SendMessageInput input)
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

                _rabbitManage.SendMsg(_cache.GetString($"{CacheKeys.ROUTER}{input.Receiver}"),message);

                _chatRecordService.Add(input);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
