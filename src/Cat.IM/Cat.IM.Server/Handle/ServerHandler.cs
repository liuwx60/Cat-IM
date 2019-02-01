using Cat.IM.Google.Protobuf;
using DotNetty.Common.Utilities;
using DotNetty.Handlers.Timeout;
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
        private string Body { get; set; }

        private readonly ILogger<ServerHandler> _logger;

        public ServerHandler(ILogger<ServerHandler> logger)
        {
            _logger = logger;
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent)
            {
                var idleStateEvent = (IdleStateEvent)evt;

                if (idleStateEvent.State == IdleState.ReaderIdle)
                {
                    _logger.LogInformation(context.Channel.Id + "-检查心跳:" + Body);
                }
            }

            base.UserEventTriggered(context, evt);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            _logger.LogError("" + exception);
            context.CloseAsync();
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, ProtobufMessage msg)
        {
            _logger.LogDebug(ctx.Channel.Id + ":" + msg.Body);

            Body = msg.Body;
        }
    }
}
