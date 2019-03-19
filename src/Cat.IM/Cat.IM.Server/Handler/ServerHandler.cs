using Cat.IM.Core;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.Controllers;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;

namespace Cat.IM.Server.Handler
{
    public class ServerHandler : SimpleChannelInboundHandler<CatMessage>
    {
        private readonly ILogger<ServerHandler> _logger;
        private readonly MessageController _messageController;

        public ServerHandler(
            ILogger<ServerHandler> logger,
            MessageController messageController
            )
        {
            _logger = logger;
            _messageController = messageController;
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            _logger.LogDebug($"[{context.GetUserId()}]下线");

            base.ChannelInactive(context);
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent idleStateEvent)
            {
                if (idleStateEvent.State == IdleState.ReaderIdle)
                {
                    _logger.LogInformation(context.Channel.Id + "-检查心跳:" + context.GetUserId());

                    _messageController.HeartBeat(context);
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

        protected override void ChannelRead0(IChannelHandlerContext ctx, CatMessage msg)
        {
            _logger.LogDebug(ctx.Channel.Id + "-收到消息:" + msg.ToString());
            
            _messageController.Executed(msg, ctx);
        }
    }
}
