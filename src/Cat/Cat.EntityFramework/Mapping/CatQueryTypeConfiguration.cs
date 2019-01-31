using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.EntityFramework.Mapping
{
    public class CatQueryTypeConfiguration<TQuery> : IMappingConfiguration, IQueryTypeConfiguration<TQuery> where TQuery : class
    {
        protected virtual void PostConfigure(QueryTypeBuilder<TQuery> builder)
        {
        }

        public virtual void Configure(QueryTypeBuilder<TQuery> builder)
        {
            this.PostConfigure(builder);
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
