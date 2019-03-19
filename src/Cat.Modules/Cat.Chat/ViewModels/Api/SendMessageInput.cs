using Cat.IM.Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.ViewModels.Api
{
    public class SendMessageInput
    {
        public Guid Id { get; set; }

        public string Body { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }

        public DateTime SendOn { get; set; }

        public CatMessage.Types.MessageType Type { get; set; } = CatMessage.Types.MessageType.Chat;
    }
}
