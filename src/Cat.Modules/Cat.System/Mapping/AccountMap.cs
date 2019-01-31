using Cat.EntityFramework.Mapping;
using Cat.System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.System.Mapping
{
    public class AccountMap : CatEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(200);
            builder.Property(x => x.NickName).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
