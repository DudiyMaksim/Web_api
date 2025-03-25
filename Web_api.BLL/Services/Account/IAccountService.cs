using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Dtos.Account;

namespace Web_api.BLL.Services.Account
{
    public interface  IAccountService
    {
        Task<AppUser?> RegisterAsync(RegisterDto dto);
        Task<AppUser?> LoginAsync(LoginDto dto);
    }
}
