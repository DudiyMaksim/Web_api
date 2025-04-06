using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Dtos.Category;
using Web_api.BLL.Dtos.Product;
using Web_api.BLL.Services.Category;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
        {
            var response = await _categoryService.CreateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto dto)
        {
            var response = await _categoryService.UpdateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не отримано");
            }

            var response = await _categoryService.DeleteAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<List<CategoryDto>?> GetAsync(string? name)
        {

            if (!string.IsNullOrEmpty(name))
            {
                var response = await _categoryService.GetByNameAsync(name);
                var json = JsonSerializer.Serialize(response.Payload);
                var categories = JsonSerializer.Deserialize<List<CategoryDto>>(json);
                if(categories != null)
                {
                    return categories;
                }
            }


            var result = await _categoryService.GetAllAsync();
            var json1 = JsonSerializer.Serialize(result.Payload);
            var categories1 = JsonSerializer.Deserialize<List<CategoryDto>>(json1);
            if (categories1 != null)
            {
                return categories1;
            }
            return null;
        }
    }
}
