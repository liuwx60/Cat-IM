using Cat.IM.Google.Protobuf;
using System;

namespace Cat.IM.Server.ViewModels.Api
{
    public class SendMessageInput
    {
        public string Id { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }

        public string Body { get; set; }

        public DateTime SendOn { get; set; }

        public CatMessage.Types.MessageType Type { get; set; } = CatMessage.Types.MessageType.Chat;
    }
}
