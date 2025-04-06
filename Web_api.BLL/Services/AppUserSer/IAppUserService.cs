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
        public Task<ServiceResponse> CreateAsync(AppUserDto dto);
        public Task<ServiceResponse> UpdateAsync(AppUserDto dto);
        public Task<ServiceResponse> DeleteAsync(AppUserDto dto);
        public Task<ServiceResponse> GetByIdAsync(string id);
        public Task<ServiceResponse> GetAllAsync();
    }
}
