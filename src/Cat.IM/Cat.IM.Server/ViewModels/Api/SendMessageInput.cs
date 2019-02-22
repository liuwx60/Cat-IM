using System;

namespace Cat.IM.Server.ViewModels.Api
{
    public class SendMessageInput
    {
        public long Id { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }

        public string Body { get; set; }

        public DateTime SendOn { get; set; }
    }
}
