using Domain.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationDBContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
      
    }
}
