using Microsoft.AspNetCore.Mvc;
using Web_api.BLL.Dtos.Product;
using Web_api.BLL.Services.Product;
using Web_api.DAL;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is required");
            }

            var product = await _productService.GetByIdAsync(id);
            return product != null ? Ok(product) : BadRequest("Product not found");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            var result = await _productService.CreateAsync(dto);
            return result.IsSuccess ? Ok("Product created") : BadRequest("Product not created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto dto)
        {
            var result = await _productService.UpdateAsync(dto);
            return result.IsSuccess ? Ok("Product updated") : BadRequest("Product not updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is required");
            }

            var result = await _productService.DeleteAsync(id);
            return result.IsSuccess ? Ok("Product deleted") : BadRequest("Product not deleted");
        }
    }
}
