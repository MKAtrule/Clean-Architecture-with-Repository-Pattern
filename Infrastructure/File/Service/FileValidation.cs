using Infrastructure.File.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.File.Service
{
    public class FileValidation : IFileValidation
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".hfif",".jfif",".svg" };
        public bool IsValidFileextension(string fileName)
        {
            var fileExtension= Path.GetExtension(fileName);
            return _allowedExtensions.Contains(fileExtension,StringComparer.OrdinalIgnoreCase);
        }
    }
}
