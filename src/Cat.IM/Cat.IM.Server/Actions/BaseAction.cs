using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Actions
{
    public class BaseAction
    {
        public void Run(ProtobufMessage msg, IChannelHandlerContext context)
        {
            var type = (MessageType)msg.Type;

            var method = GetType().GetMethod(type.ToString());

            if (method.GetParameters().Length == 1)
            {
                method.Invoke(this, new object[] { msg });
                return;
            }

            method.Invoke(this, new object[] { msg, context });
        }
    }
}
