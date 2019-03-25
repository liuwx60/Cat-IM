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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Run
{
    public class CatIMServer : IStartupFilter
    {
        private readonly ILogger<ServerHandler> _logger;
        private readonly IConfiguration _configuration;
        private readonly MessageController _messageController;
        private readonly int _heartBeatTime;
        private readonly int _port;

        public CatIMServer(
            ILogger<ServerHandler> logger,
            IConfiguration configuration,
            MessageController messageController
            )
        {
            _logger = logger;
            _configuration = configuration;
            _messageController = messageController;
            _heartBeatTime = Convert.ToInt32(_configuration["HeartBeatTime"]);
            _port = Convert.ToInt32(_configuration["Service:Port"]);
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            var webSocket = Convert.ToBoolean(_configuration["WebSocket"]);

            if (webSocket)
            {
                WebIMServer().Wait();
                return next;
            }

            IMServer().Wait();
            return next;
        }

        public async Task IMServer()
        {
            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new IdleStateHandler(_heartBeatTime, 0, 0))
                            .AddLast(new ProtobufVarint32FrameDecoder())
                            .AddLast(new ProtobufDecoder(CatMessage.Parser))
                            .AddLast(new ProtobufVarint32LengthFieldPrepender())
                            .AddLast(new ProtobufEncoder())
                            .AddLast(new ServerHandler(_logger, _messageController));
                    }));

            await bootstrap.BindAsync(_port);
        }

        public async Task WebIMServer()
        {
            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 8192)
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new IdleStateHandler(_heartBeatTime, 0, 0))
                            .AddLast(new HttpServerCodec())
                            .AddLast(new HttpObjectAggregator(65536))
                            .AddLast(new WebSocketDecoder())
                            .AddLast(new ProtobufDecoder(CatMessage.Parser))
                            .AddLast(new WebSocketEncoder())
                            .AddLast(new WebSocketServerProtocolHandler("/ws", null, true))
                            .AddLast(new ServerHandler(_logger, _messageController));
                    }));

            await bootstrap.BindAsync(_port);
        }
    }
}
