using Cat.IM.Google.Protobuf;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.IM.Client
{
    public class ClientHandler : SimpleChannelInboundHandler<CatMessage>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, CatMessage msg)
        {
            Console.WriteLine($"收到消息:{msg.ToString()}");
        }

        public override void UserEventTriggered(IChannelHandlerContext context, object evt)
        {
            if (evt is IdleStateEvent idleStateEvent)
            {
                if (idleStateEvent.State == IdleState.WriterIdle)
                {
                    var message = new CatMessage
                    {
                        Type = CatMessage.Types.MessageType.Ping,
                        Ping = new Ping { Body = "ping" }
                    };

                    context.WriteAndFlushAsync(message);
                }
            }

            base.UserEventTriggered(context, evt);
        }
    }
}
