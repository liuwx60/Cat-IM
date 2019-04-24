using Cat.IM.Google.Protobuf;
using DotNetty.Codecs.Protobuf;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cat.IM.Client
{
    class Program
    {
        static async Task RunClientAsync()
        {
            var group = new MultithreadEventLoopGroup();
            
            try
            {
                var bootstrap = new Bootstrap();
                bootstrap
                    .Group(group)
                    .Channel<TcpSocketChannel>()
                    .Option(ChannelOption.TcpNodelay, true)
                    .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline
                            .AddLast(new IdleStateHandler(0, 8, 0))
                            .AddLast(new ProtobufVarint32FrameDecoder())
                            .AddLast(new ProtobufDecoder(CatMessage.Parser))
                            .AddLast(new ProtobufVarint32LengthFieldPrepender())
                            .AddLast(new ProtobufEncoder())
                            .AddLast(new ClientHandler());
                    }));

                IChannel clientChannel = await bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8850));

                while (true)
                {
                    Console.WriteLine("1.登录 2.发送消息 Q.退出");

                    var action = Console.ReadLine();

                    if (action.ToUpper() == "Q")
                    {
                        break;
                    }

                    if (action == "1")
                    {
                        Console.WriteLine("请输入token:");

                        var token = Console.ReadLine();

                        var message = new CatMessage
                        {
                            Type = MessageType.Login,
                            Login = new Login
                            {
                                Token = token
                            }
                        };

                        await clientChannel.WriteAndFlushAsync(message);

                        continue;
                    }

                    //if (action == "2")
                    //{
                    //    Console.WriteLine("请输入接收者ID:");

                    //    var receiverId = Console.ReadLine();

                    //    Console.WriteLine($"请输入发送给{receiverId}的内容：");

                    //    var body = Console.ReadLine();

                    //    var message = new CatMessage
                    //    {
                    //        Type = CatMessage.Types.MessageType.Chat,
                    //        Chat = new Chat
                    //        {
                    //            Id = Guid.NewGuid().ToString(),
                    //            Body = body,
                    //            Receiver = receiverId,
                    //            SendOn = DateTime.Now.ToString()
                    //        }
                    //    };

                    //    await clientChannel.WriteAndFlushAsync(message);

                    //    continue;
                    //}
                }

                await clientChannel.CloseAsync();
            }
            finally
            {
                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
        }

        static void Main(string[] args)
        {
            RunClientAsync().Wait();
        }
    }
}
