using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using spr311_web_api.DAL.Entities.Identity;

namespace Web_api.BLL.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser user);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
    }
}
