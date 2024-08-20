using Application.Interface;

namespace CleanArchiRepoPrcApi.Common.Services
{
    public class HostEnvironmentService : IHostEnvironmentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HostEnvironmentService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public string WebRoothPath
        {
            get
            {
                return _webHostEnvironment.WebRootPath;
            }
        }
    }
}
