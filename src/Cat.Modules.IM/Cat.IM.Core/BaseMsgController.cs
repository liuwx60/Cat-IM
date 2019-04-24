using Cat.IM.Google.Protobuf;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.IM.Core
{
    public class BaseMsgController
    {
        public void Executed(CatMessage message, IChannelHandlerContext context)
        {
            var type = message.Type;

            var method = GetType().GetMethod(type.ToString());

            if (method == null)
            {
                return;
            }

            var paramList = new List<object>
            {
                message.GetType().GetProperty(type.ToString())?.GetValue(message),
                context
            };

            method.Invoke(this, paramList.Take(method.GetParameters().Length).ToArray());
        }
    }
}
