using Cat.Authorization.Models;
using Cat.EntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.Authorization.Mapping
{
    public class PermissionMap : CatEntityTypeConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(nameof(Permission));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);
            
            base.Configure(builder);
        }
    }
}