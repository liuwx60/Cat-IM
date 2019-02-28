using Cat.Authorization.Filter;
using Cat.Chat.ViewModels.Api;
using Cat.Core;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("sendMessage")]
        public IActionResult SendMsg(SendMessageInput input)
        {
            try
            {
                var client = new RestClient("http://localhost:55834/api/sendMessage");

                var request = new RestRequest(Method.POST)
                    .AddJsonBody(input);

                var response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
