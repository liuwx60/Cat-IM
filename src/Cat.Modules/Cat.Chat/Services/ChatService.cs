using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Services
{
    public class ChatService : IChatService
    {
        public void SendMsg(object input)
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
    }
}
