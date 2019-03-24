using Cat.Chat.Models;
using Cat.EntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Chat.Mapping
{
    public class OfflineMessageMap : CatEntityTypeConfiguration<OfflineMessage>
    {
        public override void Configure(EntityTypeBuilder<OfflineMessage> builder)
        {
            builder.ToTable(nameof(OfflineMessage));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Body).HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
