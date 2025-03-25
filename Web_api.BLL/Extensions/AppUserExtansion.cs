using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Services.AppUserSer;

namespace Web_api.BLL.Extensions
{
    internal static class AppUserExtansion
    {
        public static async Task CreateAsync(this AppUser user, AppUserService userService, AppUserDto dto)
        {
            await userService.CreateAsync(dto);
        }

        public static async Task UpdateAsync(this AppUser user, AppUserService userService, AppUserDto dto)
        {
            await userService.UpdateAsync(dto);
        }

        public static async Task DeleteAsync(this AppUser user, AppUserService userService, AppUserDto dto)
        {
            await userService.DeleteAsync(dto);
        }
        public static async Task<AppUser?> GetByIdAsync(this AppUser user, AppUserService userService, string id)
        { 
            return await userService.GetByIdAsync(id);
        }
        public static async Task<List<AppUser>?> GetAllAsync(this AppUser user, AppUserService userService)
        {
            return await userService.GetAllAsync();
        }
    }
}
