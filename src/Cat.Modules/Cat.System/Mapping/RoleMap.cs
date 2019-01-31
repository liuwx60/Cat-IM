using Cat.EntityFramework.Mapping;
using Cat.System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.System.Mapping
{
    public class RoleMap : CatEntityTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
