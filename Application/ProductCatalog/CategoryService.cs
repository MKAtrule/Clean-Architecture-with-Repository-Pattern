using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.IRepo;
using AutoMapper;
using Domain.Product;
namespace Application.ProductCatalog
{
    public class CategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<CategoryResposeDTO> CreateAsync(CategoryRequestDTO request)
        {
            var category = mapper.Map<Category>(request);
            category.IsActive = true;
            var newCategory= await categoryRepository.Create(category);
            var categoryResponse= mapper.Map<CategoryResposeDTO>(newCategory);
            return categoryResponse;
        }
        public async Task<List<CategoryResposeDTO>> GetAllAsync()
        {
            var categories= await categoryRepository.GetAll();  
            return   mapper.Map<List<CategoryResposeDTO>>(categories.Where(ct=>ct.IsActive).ToList());
           
        }
        public async Task<CategoryResposeDTO> UpdateAsync(CategoryRequestDTO request)
        {
            throw new NotImplementedException();    
            //var category = await categoryRepository.GetById(request.Id);
            // var updatedRequest= mapper.Map<Category>(request);
            ////category.Description = request.Description;
            ////category.Name = request.CategoryName;
            //var updatedCategory = await categoryRepository.Update(updatedRequest);
            //var updatedResposne = mapper.Map<CategoryResposeDTO>(updatedCategory);
            //return updatedResposne;
        }
        public async Task<CategoryResposeDTO> DeleteAsync(Guid id)
        {

            var delCategory = await categoryRepository.GetById(id);
            if(delCategory != null)
            {
                var category= await categoryRepository.Delete(delCategory);
                return mapper.Map<CategoryResposeDTO>(category);    
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
    }
}
