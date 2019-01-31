using Cat.EntityFramework.Mapping;
using Cat.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.Users.Mapping
{
    public class UserMap : CatEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(200);
            builder.Property(x => x.NickName).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Mobile).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
