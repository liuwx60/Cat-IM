using Cat.IM.Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Rabbit.Manager
{
    public interface IRabbitManager
    {
        void SendMsg(string routeKey, CatMessage message, string queueName = "Cat.IM.Chat");

        void Receiver(string routeKey, Action<CatMessage> action = null, string queueName = "Cat.IM.Chat");
    }
}
