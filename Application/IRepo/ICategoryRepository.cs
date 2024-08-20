using Domain.Interfaces;
using Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepo
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<Category> GetById(Guid id); 
    }
}
