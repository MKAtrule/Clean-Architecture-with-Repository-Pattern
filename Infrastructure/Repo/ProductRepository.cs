using Application.IRepo;
using Domain.Product;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDBcontext _context;
        public ProductRepository(ApplicationDBcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product> GetById(Guid id)
        {
            return await _context.Product
                          .FirstOrDefaultAsync(pr=>pr.Id==id);
        }

        public async Task<List<Product>> GetProductByCategory(Guid categoryId)
        {
                  return await _context.Product.Where(pr=>pr.CategoryId==categoryId)
                                                .ToListAsync();

        }
    }
}
