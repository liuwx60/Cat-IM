using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Cat.IM.Core.Codecs
{
    public class WebSocketEncoder : MessageToMessageEncoder<IMessage>
    {
        protected override void Encode(IChannelHandlerContext context, IMessage message, List<object> output)
        {
            Contract.Requires(context != null);
            Contract.Requires(message != null);
            Contract.Requires(output != null);

            IByteBuffer buffer = null;

            try
            {
                int size = message.CalculateSize();
                if (size == 0)
                {
                    return;
                }

                buffer = Unpooled.WrappedBuffer(message.ToByteArray());

                var frame = new BinaryWebSocketFrame(buffer);

                output.Add(frame);
                buffer = null;
                frame = null;
            }
            catch (Exception exception)
            {
                throw new CodecException(exception);
            }
            finally
            {
                buffer?.Release();
            }
        }
    }
}
