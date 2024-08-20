using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.RequestDTO
{
    public class ProductRequestDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float  Price { get; set; }
        public IFormFile Image {  get; set; } 
        public Guid CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }=DateTime.Now;
    }
}
