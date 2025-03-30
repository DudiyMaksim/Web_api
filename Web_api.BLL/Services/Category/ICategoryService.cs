using Web_api.BLL.Dtos.Category;

namespace Web_api.BLL.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse> CreateAsync(CreateCategoryDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateCategoryDto dto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<CategoryDto> GetByNameAsync(string name);
    }
}
