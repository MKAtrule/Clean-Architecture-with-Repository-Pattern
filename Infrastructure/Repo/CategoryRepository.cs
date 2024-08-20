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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBcontext _context;
        public CategoryRepository(ApplicationDBcontext context):base(context) 
        {
            _context = context;
        }
        public async Task<Category> GetById(Guid id)
        {
            return await _context.Category
                        .FirstOrDefaultAsync(ct=>ct.Id==id);
        }
    }
}
