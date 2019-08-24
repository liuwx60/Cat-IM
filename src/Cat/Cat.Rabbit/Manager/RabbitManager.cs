using Cat.IM.Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cat.Rabbit.Manager
{
    public class RabbitManager : IRabbitManager
    {
        private const string QueueName = "Cat.IM.Chat";
        private const string ExchangeName = "Cat.IM";

        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ILogger<RabbitManager> _logger;

        public RabbitManager(
            IConfiguration configuration,
            ILogger<RabbitManager> logger
            )
        {
            _logger = logger;

            _connectionFactory = new ConnectionFactory
            {
                HostName = configuration["Rabbit:HostName"],
                Port = int.Parse(configuration["Rabbit:Port"]),
                UserName = configuration["Rabbit:UserName"],
                Password = configuration["Rabbit:Password"]
            };

            _connection = _connectionFactory.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Topic, true);
        }

        public void SendMsg(string routeKey, CatMessage message, string queueName = "Cat.IM.Chat")
        {
            if (string.IsNullOrWhiteSpace(routeKey))
            {
                _logger.LogInformation($"用户[{message.Chat.Info.Receiver}]不在线！");

                return;
            }

            _channel.QueueDeclare(queueName, true, false, false, null);

            _channel.QueueBind(queueName, ExchangeName, routeKey);

            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.DeliveryMode = 2;

            var address = new PublicationAddress(ExchangeType.Topic, ExchangeName, routeKey);

            byte[] buffer = null;

            using (var memoryStream = new MemoryStream())
            {
                using (var output = new Google.Protobuf.CodedOutputStream(memoryStream))
                {
                    message.WriteTo(output);
                }

                buffer = memoryStream.ToArray();
            }

            _channel.BasicPublish(address, basicProperties, buffer);
        }

        public void Receiver(string routeKey, Action<CatMessage> action = null, string queueName = "Cat.IM.Chat")
        {
            _channel.QueueDeclare(queueName, true, false, false, null);

            _channel.QueueBind(queueName, ExchangeName, routeKey);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ch, ea) =>
            {
                using (Google.Protobuf.CodedInputStream input = new Google.Protobuf.CodedInputStream(ea.Body))
                {
                    var message = new CatMessage();

                    message.MergeFrom(input);

                    action?.Invoke(message);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queueName, false, consumer);
        }
    }
}
