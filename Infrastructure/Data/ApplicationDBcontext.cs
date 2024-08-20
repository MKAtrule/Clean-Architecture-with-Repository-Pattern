using Application.Interface;
using Domain.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDBcontext : DbContext, IApplicationDBContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options):base(options)
        {
            
        }
        public DbSet<Category> Category {  get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBcontext).Assembly); 
        }

    }
}
