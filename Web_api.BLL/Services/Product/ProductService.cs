using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web_api.BLL.Dtos.Product;
using Web_api.DAL;
using Web_api.DAL.Entities;

namespace Web_api.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);

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

            var dtos = _mapper.Map<List<ProductDto>>(entities);
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

            var dto = _mapper.Map<ProductDto>(entity);

            return dto;
        }

        public async Task<ProductDto?> GetByPriceAsync(int from, int to)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Price >= from && p.Price <= to);

            var dto = _mapper.Map<ProductDto?>(entity);

            return dto;
        }

        public async Task<bool> UpdateAsync(UpdateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);

            _context.Products.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
