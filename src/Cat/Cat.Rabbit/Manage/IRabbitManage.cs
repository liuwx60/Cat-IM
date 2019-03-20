using Cat.IM.Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Rabbit.Manage
{
    public interface IRabbitManage
    {
        void SendMsg(string routeKey, CatMessage message);

        void Receiver(string routeKey, Action<CatMessage> action);
    }
}
