using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.IRepo;
using AutoMapper;
using Domain.Product;
using Infrastructure.File.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductCatalog
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository, IFileService fileService, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }
        public async Task<ProductResposneDTO> CreateAsync(ProductRequestDTO request)
        {

            if (request.Image != null && request.Image.Length > 0)
            {
                string imagepath = await fileService.UploadFileAsync(request.Image);
                var product = mapper.Map<Product>(request);
                product.Image = imagepath;
                product.CreatedAt = DateTime.Now;
                var newProduct = await productRepository.Create(product);
                return mapper.Map<ProductResposneDTO>(newProduct);

            }
            else
            {
                throw new Exception("Image is required");
            }


        }
        public async Task<List<ProductResposneDTO>> GetProductsByCategory(Guid categoryId)
        => mapper.Map<List<ProductResposneDTO>>(await productRepository.GetProductByCategory(categoryId));
        public async Task<List<ProductResposneDTO>> GetAllAsync()
        => mapper.Map<List<ProductResposneDTO>>(await productRepository.GetAll());
        public async Task<ProductResposneDTO> RemoveAsync(Guid productId)
        {
            var product = await productRepository.GetById(productId);
            if (product != null)
            {
                return mapper.Map<ProductResposneDTO>(await productRepository.Delete(product));

            }
            else
            {
                throw new Exception("Product Not Found");
            }

        }
        public async Task<ProductResposneDTO> UpdateAsync(ProductUpdateRequestDTO request)
        {
            if(request.Image != null && request.Image.Length>0)
            {
                string image=await fileService.UploadFileAsync(request.Image);
                var product = await productRepository.GetById(request.Id);
                if (product != null)
                {
                    product.Image = image;  
                    return mapper.Map<ProductResposneDTO>(await productRepository.Update(product));
                }
                else
                {
                    throw new Exception("Product Not Found");
                }
            }
            else
            {
                throw new Exception("Image is Required");
            }
           
        }
    }
}
