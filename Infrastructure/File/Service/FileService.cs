using Microsoft.AspNetCore.Http;
using Application.Interface;
using Infrastructure.File.Interface;

namespace Infrastructure.File.Service
{
    public class FileService : IFileService
    {
        private readonly IFileValidation _fileValidation;
        private readonly IHostEnvironmentService hostEnvironment;
        public FileService(IFileValidation fileValidation, IHostEnvironmentService hostEnvironment)
        {
            _fileValidation = fileValidation;
            this.hostEnvironment = hostEnvironment;
        }


        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("File is required");
            }
            if (!_fileValidation.IsValidFileextension(file.FileName))
            {
                throw new Exception("Invalid file type. Only PNG, JPG, JPEG, SVG, GIF, BMP, WEBP, TIFF files are allowed.");
            }
            var uploadDir = Path.Combine(hostEnvironment.WebRoothPath, "uploads");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            var imageUniqueFileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
            var imageFilepath = Path.Combine(uploadDir, imageUniqueFileName);
            using (var fileStream = new FileStream(imageFilepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return "/uploads/" + imageUniqueFileName;
        }
    }
}
