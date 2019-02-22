using Cat.IM.Core.Codecs;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.Controllers;
using Cat.IM.Server.Handler;
using DotNetty.Codecs.Http;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cat.IM.Server
{
    public static class CatIMServer
    {
        public static IChannel BoundChannel;

        public async static void AddIMServer(this IServiceCollection services, int heartBeatTime)
        {
            var logger = services.BuildServiceProvider().GetService<ILogger<ServerHandler>>();
            var action = services.BuildServiceProvider().GetService<MessageController>();

            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new IdleStateHandler(heartBeatTime, 0, 0))
                            .AddLast(new ProtobufVarint32FrameDecoder())
                            .AddLast(new ProtobufDecoder(CatMessage.Parser))
                            .AddLast(new ProtobufVarint32LengthFieldPrepender())
                            .AddLast(new ProtobufEncoder())
                            .AddLast(new ServerHandler(logger, action));
                    }));

                BoundChannel = await bootstrap.BindAsync(8850);
            }
            catch(Exception ex)
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));

                throw ex;
            }
        }

        public async static void AddWebIMServer(this IServiceCollection services, int heartBeatTime)
        {
            var logger = services.BuildServiceProvider().GetService<ILogger<ServerHandler>>();
            var action = services.BuildServiceProvider().GetService<MessageController>();

            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 8192)
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new IdleStateHandler(heartBeatTime, 0, 0))
                            .AddLast(new HttpServerCodec())
                            .AddLast(new HttpObjectAggregator(65536))
                            .AddLast(new WebSocketDecoder())
                            .AddLast(new ProtobufDecoder(CatMessage.Parser))
                            .AddLast(new WebSocketEncoder())
                            .AddLast(new WebSocketServerProtocolHandler("/ws", null, true))
                            .AddLast(new ServerHandler(logger, action));
                    }));

                BoundChannel = await bootstrap.BindAsync(8850);
            }
            catch (Exception ex)
            {
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));

                throw ex;
            }
        }
    }
}
