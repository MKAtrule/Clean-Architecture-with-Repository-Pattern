using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interface
{
    public interface IAutiableEntity
    {
        bool IsActive { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime DeletedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
