using Application.Interface;
using Application.IRepo;
using Application.ProductCatalog;
using Infrastructure.Data;
using Infrastructure.File.Interface;
using Infrastructure.File.Service;
using Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public static class ServiceConfiguration
    {
        public static void Configuration( IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<CategoryService>();
            services.AddTransient<IFileValidation,FileValidation>(); 
            services.AddScoped<IFileService,FileService>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ProductService>();
        }

    }
}
