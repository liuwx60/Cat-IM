using System;
using System.Collections.Generic;
using System.Text;
using Cat.Chat.Models;
using Cat.Chat.ViewModels.Api;
using Cat.Core.Data;

namespace Cat.Chat.Services
{
    public class ChatRecordService : IChatRecordService
    {
        private readonly IRepository<ChatRecord> _chatRecordRepository;

        public ChatRecordService(IRepository<ChatRecord> chatRecordRepository)
        {
            _chatRecordRepository = chatRecordRepository;
        }

        public void Add(SendMessageInput input)
        {
            var chatRecord = new ChatRecord
            {
                Id = input.Id,
                Body = input.Body,
                Sender = input.Sender,
                Receiver = input.Receiver,
                SendOn = input.SendOn,
                Type = input.Type
            };

            _chatRecordRepository.Insert(chatRecord);
        }
    }
}
