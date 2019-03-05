using Cat.Chat.Models;
using Cat.EntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Mapping
{
    public class ChatRecordMap : CatEntityTypeConfiguration<ChatRecord>
    {
        public override void Configure(EntityTypeBuilder<ChatRecord> builder)
        {
            builder.ToTable(nameof(ChatRecord));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Body).HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
