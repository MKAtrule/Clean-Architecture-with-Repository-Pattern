using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.File.Interface
{
    public interface IFileValidation
    {
        bool IsValidFileextension(string fileName);
    }
}
