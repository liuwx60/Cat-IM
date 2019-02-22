using DotNetty.Codecs;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.IM.Core.Codecs
{
    public class WebSocketDecoder : MessageToMessageDecoder<WebSocketFrame>
    {
        protected override void Decode(IChannelHandlerContext context, WebSocketFrame message, List<object> output)
        {
            var buf = message.Content;
            output.Add(buf);
            buf.Retain();
        }
    }
}
