using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.RequestDTO
{
    public class ProductUpdateRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public IFormFile Image { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
