using Application.DTO.RequestDTO;
using Application.ProductCatalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchiRepoPrcApi.Controllers
{

    public class ProductController : BaseController
    {
        private readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost("CreateProduct")]
        public async Task<JsonResult> Create([FromForm] ProductRequestDTO request)
        {
            try
            {
                return new JsonResult
                (
                new
                {
                    success = true,
                    data = await productService.CreateAsync(request),
                    message = "Created SuccessFully"
                }
                    );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        [HttpGet("GetAllProducts")]
        public async Task<JsonResult> GetAll()
        {
            try
            {
                return new JsonResult
                (
                new
                {
                    success = true,
                    data = await productService.GetAllAsync(),
                    message = "Listed SuccessFully"
                }
                    );
                ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpGet("/{categoryId}")]
        public async Task<JsonResult> Get(Guid categoryId)
        {
            try
            {
                return new JsonResult
                (
                new
                {
                    success = true,
                    data = await productService.GetProductsByCategory(categoryId),
                    message = "Listed SuccessFully"
                }
                    );
                ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpPut("UpdateProduct")]
        public async Task<JsonResult> Put([FromForm]ProductUpdateRequestDTO request)
        {
            try
            {
                return new JsonResult
                (
                new
                {
                    success = true,
                    data = await productService.UpdateAsync(request),
                    message = "Updated SuccessFully"
                }
                    );
                ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            try
            {
                return new JsonResult
                (
                new
                {
                    success = true,
                    data = await productService.RemoveAsync(id),
                    message = "Deleted SuccessFully"
                }
                    );
                ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
