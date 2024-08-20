using Domain.Interfaces;
using Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepo
{
    public interface IProductRepository:IBaseRepository<Product>    
    {
        Task<Product> GetById(Guid id);
        Task<List<Product>> GetProductByCategory(Guid categoryId);
    }
}
