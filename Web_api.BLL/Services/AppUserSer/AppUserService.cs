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

        public async Task CreateAsync(AppUserDto dto)
        {
            var user = new AppUser
            {
                UserName = dto.Name,
                Email = dto.Email
            };

            await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task DeleteAsync(AppUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Name);
            if (user == null)
            {
                return;
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task<List<AppUser>?> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task UpdateAsync(AppUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Name);
            if (user == null)
            {
                return;
            }
            await _userManager.UpdateAsync(user);
        }
    }
}
