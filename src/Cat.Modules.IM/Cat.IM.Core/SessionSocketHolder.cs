using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.IM.Core
{
    public class SessionSocketHolder
    {
        public static Dictionary<Guid, IChannelHandlerContext> Channels = new Dictionary<Guid, IChannelHandlerContext>();

        public static void Add(Guid userId, IChannelHandlerContext context)
        {
            if (Channels.ContainsKey(userId))
            {
                Channels[userId] = context;
                return;
            }

            Channels.Add(userId, context);
        }

        public static IChannelHandlerContext Get(Guid userId)
        {
            Channels.TryGetValue(userId, out IChannelHandlerContext context);

            return context;
        }
    }
}
