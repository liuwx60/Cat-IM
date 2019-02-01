using Cat.IM.Google.Protobuf;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.IM.Server.Actions
{
    public class MessageAction : BaseAction
    {
        private readonly ILogger<MessageAction> _logger;

        public MessageAction(ILogger<MessageAction> logger)
        {
            _logger = logger;
        }

        public void Login(ProtobufMessage input)
        {
            _logger.LogInformation(input.ToString());
        }
    }
}
