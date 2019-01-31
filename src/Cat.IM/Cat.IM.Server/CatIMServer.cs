using Cat.IM.Google.Protobuf;
using Cat.IM.Server.Handle;
using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server
{
    public static class CatIMServer
    {
        public async static void AddIMServer(this IServiceCollection services)
        {
            var handler = services.BuildServiceProvider().GetService<ServerHandler>();

            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .Handler(new LoggingHandler("SRV-LSTN"))
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new LoggingHandler("SRV-CONN"))
                            .AddLast(new IdleStateHandler(60, 0, 0))
                            .AddLast(new ProtobufVarint32FrameDecoder())
                            .AddLast(new ProtobufDecoder(ProtobufMessage.Parser))
                            .AddLast(new ProtobufVarint32LengthFieldPrepender())
                            .AddLast(new ProtobufEncoder())
                            .AddLast(handler);
                    }));

                IChannel boundChannel = await bootstrap.BindAsync(8850);
            }
            finally
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }
}
