using Domain.Common;
using Domain.Common.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product
{
    public class Product:AuditableWihBaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image {  get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
