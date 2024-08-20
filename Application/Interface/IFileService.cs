using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.File.Interface
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);

    }
}
