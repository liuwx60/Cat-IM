using Cat.Core;
using Cat.IM.Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Models
{
    public class ChatRecord : BaseEntity
    {
        public string Body { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }

        public DateTime SendOn { get; set; }

        public CatMessage.Types.MessageType Type { get; set; } = CatMessage.Types.MessageType.Chat;

        public bool Received { get; set; }

        public bool Read { get; set; }

        public DateTime CreateOn { get; set; } = DateTime.Now;

        public DateTime UpdateOn { get; set; } = DateTime.Now;
    }
}
