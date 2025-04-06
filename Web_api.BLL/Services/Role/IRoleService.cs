using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_api.BLL.Dtos.Role;
using Web_api.BLL.Services.Account;

namespace Web_api.BLL.Services.Role
{
    public interface IRoleService
    {
        Task<ServiceResponse> CreateAsync(CreateRoleDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateRoleDto dto); 
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();
    }
}
