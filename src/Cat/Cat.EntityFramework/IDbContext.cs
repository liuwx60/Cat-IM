using Cat.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.EntityFramework
{
    public partial interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        
        int SaveChanges();
    }
}
