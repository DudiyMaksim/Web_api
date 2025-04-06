using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Account;
using Web_api.DAL;
using Web_api.BLL.Services;

namespace Web_api.BLL.Services.AppUserSer
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse> CreateAsync(AppUserDto dto)
        {
            var user = new AppUser
            {
                UserName = dto.Name,
                Email = dto.Email
            };

            await _userManager.CreateAsync(user, dto.Password);
            return ServiceResponse.Success("Клієнт створений");
        }

        public async Task<ServiceResponse> DeleteAsync(AppUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Name);
            if (user == null)
            {
                return ServiceResponse.Error("Клієнт не знайдений");
            }

            await _userManager.DeleteAsync(user);
            return ServiceResponse.Success("Клієнт видалений");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            return ServiceResponse.Success("Товари отримано", await _userManager.Users.ToListAsync());
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            await _userManager.FindByIdAsync(id);
            return ServiceResponse.Success("Клієнт отримано");
        }

        public async Task<ServiceResponse> UpdateAsync(AppUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Name);
            if (user == null)
            {
                return ServiceResponse.Success("Клієнт не знайдено");
            }
            await _userManager.UpdateAsync(user);
            return ServiceResponse.Success("Клієнт оновлений");
        }
    }
}
