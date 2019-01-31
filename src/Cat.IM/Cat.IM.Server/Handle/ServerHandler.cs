using Cat.IM.Google.Protobuf;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Handle
{
    public class ServerHandler : SimpleChannelInboundHandler<ProtobufMessage>
    {
        private readonly ILogger<ServerHandler> _logger;

        public ServerHandler(ILogger<ServerHandler> logger)
        {
            _logger = logger;
        }
        
        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            _logger.LogError("Exception: " + exception);
            context.CloseAsync();
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, ProtobufMessage msg)
        {
            _logger.LogDebug(msg.Body);
        }
    }
}
