using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using spr311_web_api.DAL.Entities.Identity;
using Microsoft.Extensions.Options;
using Web_api.BLL.Configuration;
using Microsoft.AspNetCore.Identity;
using Web_api.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web_api.BLL.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IOptions<JwtSettings> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtSettings = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Користувача не знайдено." });
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }

        public string GenerateJwtToken(AppUser user)
        {
            var claims = new Claim[]
                {
                new Claim("userId", user.Id),
                new Claim("email", user.Email ?? ""),
                new Claim("userName", user.UserName ?? ""),
                new Claim("firstName", user.FirstName ?? ""),
                new Claim("lastName", user.LastName ?? "")
                };

            if (user.UserRoles != null)
            {
                foreach (var userRole in user.UserRoles)
                {
                    if (userRole.Role != null)
                    {
                        claims.Append(new System.Security.Claims.Claim(ClaimTypes.Role, userRole.Role.Name));
                    }
                }
            }


            var bytes = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var securityKey = new SymmetricSecurityKey(bytes);

            var securityToken = new JwtSecurityToken(
            audience: _jwtSettings.Audience,
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpMinutes),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
