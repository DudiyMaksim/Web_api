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
        Task<bool> CreateAsync(CreateRoleDto dto);
        Task<bool> UpdateAsync(UpdateRoleDto dto); 
        Task<bool> DeleteAsync(string id);
        Task<RoleDto?> GetByIdAsync(string id);
        Task<IEnumerable<RoleDto>> GetAllAsync();
    }
}
