using DotNetty.Codecs;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace Cat.IM.Core.Codecs
{
    public class WebSocketDecoder : MessageToMessageDecoder<WebSocketFrame>
    {
        protected override void Decode(IChannelHandlerContext context, WebSocketFrame message, List<object> output)
        {
            var channel = context.Channel;

            if (message is CloseWebSocketFrame)
            {
                var frame = (CloseWebSocketFrame)message.Retain();

                channel.WriteAndFlushAsync(frame).ContinueWith((t, s) => ((IChannel)s).CloseAsync(),
                    channel, TaskContinuationOptions.ExecuteSynchronously);
            }

            if (message is BinaryWebSocketFrame)
            {
                var buf = message.Content;
                output.Add(buf);
                buf.Retain();
            }
        }
    }
}
