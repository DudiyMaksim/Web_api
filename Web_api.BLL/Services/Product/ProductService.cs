using Microsoft.EntityFrameworkCore;
using Web_api.BLL.Dtos.Product;
using Web_api.DAL;
using Web_api.DAL.Entities;

namespace Web_api.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<bool> CreateAsync(CreateProductDto dto)
        {
            var entity = new ProductEntity
            {
                Name = dto.Name,
                Amount = dto.Amount,
                Description = dto.Description,
                Price = dto.Price
            };

            await _context.Products.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                return false;
            }

            _context.Products.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var entities = await _context.Products.ToListAsync();

            var dtos = entities.Select(e => new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Amount = e.Amount,
                Description = e.Description,
                Price = e.Price
            });
            return dtos;
        }

        public async Task<ProductDto?> GetByIdAsync(string id)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                return null;
            }

            var dto = new ProductDto
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Description = entity.Description,
                Price = entity.Price,
                Name = entity.Name
            };

            return dto;
        }

        public async Task<bool> UpdateAsync(UpdateProductDto dto)
        {
            var entity = new ProductEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Amount = dto.Amount,
                Description = dto.Description,
                Price = dto.Price
            };

            _context.Products.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
