using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.Actions;
using DotNetty.Common.Utilities;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Handler
{
    public class ServerHandler : SimpleChannelInboundHandler<ProtobufMessage>
    {
        private Guid UserId { get; set; }

        private readonly ILogger<ServerHandler> _logger;
        private readonly MessageAction _messageAction;

        public ServerHandler(
            ILogger<ServerHandler> logger,
            MessageAction messageAction
            )
        {
            _logger = logger;
            _messageAction = messageAction;
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
                    _logger.LogInformation(context.Channel.Id + "-检查心跳:" + UserId);
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
            _logger.LogDebug("收到消息:" + msg.ToString());
            
            _messageAction.Run(msg, ctx);
        }
    }
}
