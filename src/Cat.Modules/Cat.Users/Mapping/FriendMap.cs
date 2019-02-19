using Cat.EntityFramework.Mapping;
using Cat.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users.Mapping
{
    public class FriendMap : CatEntityTypeConfiguration<Friend>
    {
        public override void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable(nameof(Friend));
            builder.HasKey(x => x.Id);
            
            base.Configure(builder);
        }
    }
}
