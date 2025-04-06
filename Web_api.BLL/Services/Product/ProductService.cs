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

        public async Task<ServiceResponse> CreateAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);

            await _context.Products.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return ServiceResponse.Success("Продук створено");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                return ServiceResponse.Error("Продук не знайдено");
            }

            _context.Products.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return ServiceResponse.Success("Продук видалено");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _context.Products.ToListAsync();

            var dtos = _mapper.Map<List<ProductDto>>(entities);
            return ServiceResponse.Success("Продукти отримано", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                return ServiceResponse.Error("Продук не знайдено");
            }

            var dto = _mapper.Map<ProductDto>(entity);

            return ServiceResponse.Success("Продук отримано", dto);
        }

        public async Task<ServiceResponse> GetByPriceAsync(int from, int to)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(p => p.Price >= from && p.Price <= to);

            var dto = _mapper.Map<ProductDto?>(entity);

            return ServiceResponse.Success("Продук отримано", dto);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProductDto dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);

            _context.Products.Update(entity);
            var result = await _context.SaveChangesAsync();
            return ServiceResponse.Success("Продук оновлено");
        }
    }
}
