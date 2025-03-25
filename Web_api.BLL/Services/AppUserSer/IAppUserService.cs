using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Account;

namespace Web_api.BLL.Services.AppUserSer
{
    public interface IAppUserService
    {
        public Task CreateAsync(AppUserDto dto);
        public Task UpdateAsync(AppUserDto dto);
        public Task DeleteAsync(AppUserDto dto);
        public Task<AppUser?> GetByIdAsync(string id);
        public Task<List<AppUser>?> GetAllAsync();
    }
}
