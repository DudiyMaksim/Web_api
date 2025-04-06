using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_api.BLL.Dtos.Product;

namespace Web_api.BLL.Services.Product
{
    public interface IProductService
    {
        public Task<ServiceResponse> CreateAsync(CreateProductDto dto);
        public Task<ServiceResponse> UpdateAsync(UpdateProductDto dto);
        public Task<ServiceResponse> DeleteAsync(string id);
        public Task<ServiceResponse> GetByIdAsync(string id);
        public Task<ServiceResponse> GetByPriceAsync(int from, int to);
        public Task<ServiceResponse> GetAllAsync();
    }
}
