using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ResponseDTO
{
    public class ProductResposneDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; } 
        public float Price { get; set; }
       
        public Guid CategoryId { get; set; }
      
    }
}
