using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Role;

namespace Web_api.BLL.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ServiceResponse> CreateAsync(CreateRoleDto dto)
        {
            var entity = new AppRole
            {
                Name = dto.Name
            };

            var result = await _roleManager.CreateAsync(entity);

            return ServiceResponse.Success("Роль створено");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error("Роль не знайдено");
            }

            var result = await _roleManager.DeleteAsync(entity);

            return ServiceResponse.Success("Роль видалена");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _roleManager.Roles.ToListAsync();

            var dtos = entities.Select(e => new RoleDto
            {
                Id = e.Id,
                Name = e.Name ?? "No name"
            });

            return ServiceResponse.Success("Ролі отримані", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error("роль не знайдено");
            }

            var dto = new RoleDto
            {
                Id = entity.Id,
                Name = entity.Name ?? "noname"
            };

            return ServiceResponse.Success("Роль отримана", dto);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateRoleDto dto)
        {
            var entity = new AppRole
            {
                Name = dto.Name
            };

            var result = await _roleManager.UpdateAsync(entity);

            return ServiceResponse.Success("Роль оновлена");
        }
    }
}
