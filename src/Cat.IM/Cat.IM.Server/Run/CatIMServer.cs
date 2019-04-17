using Cat.IM.Core.Codecs;
using Cat.IM.Google.Protobuf;
using Cat.IM.Server.Controllers;
using Cat.IM.Server.Handler;
using DotNetty.Codecs.Http;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Timeout;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.IM.Server.Run
{
    public class CatIMServer : IHostedService
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
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var webSocket = Convert.ToBoolean(_configuration["WebSocket"]);

            if (webSocket)
            {
                await WebIMServer();
                return;
            }

            await IMServer();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
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

            var isSsl = Convert.ToBoolean(_configuration["SSL:IsSsl"]);

            X509Certificate2 tlsCertificate = null;
            if (isSsl)
            {
                var path = _configuration["SSL:Path"];
                var password = _configuration["SSL:Password"];

                tlsCertificate = string.IsNullOrWhiteSpace(password) ? new X509Certificate2(path) : new X509Certificate2(path, password);
            }

            var bootstrap = new ServerBootstrap()
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 8192)
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;

                        if (isSsl)
                        {
                            pipeline.AddLast(TlsHandler.Server(tlsCertificate));
                        }

                        pipeline
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
