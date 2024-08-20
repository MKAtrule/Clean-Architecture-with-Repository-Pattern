using Application.DTO.RequestDTO;
using Application.ProductCatalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchiRepoPrcApi.Controllers
{
       public class CategoryController : BaseController
       {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CategoryRequestDTO request)
        {
            try
            {
                return new JsonResult
                (
                new
                {
                        success = true,
                        data = await _categoryService.CreateAsync(request),
                        message = "Created SuccessFully"
                    }
                    );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                return new JsonResult
                (
                new
                {
                        success = true,
                        data = await _categoryService.GetAllAsync(),
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

        
        [HttpPut]
        public async Task<JsonResult> Put([FromBody] CategoryRequestDTO request)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _categoryService.UpdateAsync(request),
                    Message = "Update SuccessFully"

                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _categoryService.DeleteAsync(id),
                    Message = "Deleted SuccessFully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

       
    }
}
