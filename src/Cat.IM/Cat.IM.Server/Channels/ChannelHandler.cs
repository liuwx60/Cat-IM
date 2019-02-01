using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Channels
{
    public class ChannelHandler
    {
        public static Dictionary<Guid, IChannelHandlerContext> Channels = new Dictionary<Guid, IChannelHandlerContext>();

        public static void Add(Guid userId, IChannelHandlerContext context)
        {
            Channels.Add(userId, context);
        }

        public static IChannelHandlerContext Get(Guid userId)
        {
            return Channels[userId];
        }
    }
}
