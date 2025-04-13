using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using spr311_web_api.DAL.Entities.Identity;
using Web_api.BLL.Configuration;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Services.EmailService;
using Web_api.BLL.Services.Image;
using Web_api.DAL.Entities;
using System.Security.Claims;
using Web_api.BLL.Services.Jwt;


namespace Web_api.BLL.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;

        public AccountService(UserManager<AppUser> userManager, IEmailService emailService,  IJwtService jwtService, IMapper mapper = null, IImageService imageService = null)
        {
            _userManager = userManager;
            _mapper = mapper;
            _imageService = imageService;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<ServiceResponse> RegisterAsync(RegisterDto dto)
        {
            if (!await IsUniqueEmailAsync(dto.Email))
            {
                return ServiceResponse.Error("Email користувача не унікальний");
            }
            if (!await IsUniqueUserNameAsync(dto.UserName))
            {
                return ServiceResponse.Error("Ім'я користувача не унікальне");
            }

            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var entity = _mapper.Map<AppUser>(dto);

            //images
            string dirPath = Path.Combine(Settings.AccountsDir, Guid.NewGuid().ToString());
            Directory.CreateDirectory(dirPath);
            var imageName = await _imageService.SaveImageAsync(dto.Image, dirPath);

            var imageEntity = new AccountImagesEntity
            {
                Name = imageName,
                Path = dirPath,
                UserId = entity.Id
            };

            var result = await _userManager.CreateAsync(entity, dto.Password);

            if (result.Succeeded)
            {
                return ServiceResponse.Success("Успішна реєстрація");
            }

            return ServiceResponse.Error(result.Errors.First().Description);
        }

        public async Task<ServiceResponse> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
            {
                return ServiceResponse.Error($"Користувача з іменем {dto.UserName} не знайдено");
            }

            if (await IsCorrectPasswordAsync(dto))
            {
                string jwtToken = _jwtService.GenerateJwtToken(user);

                return ServiceResponse.Success("Успішний вхід", jwtToken);
            }

            return ServiceResponse.Error("Пароль вказано не вірно");
        }


        private async Task<bool> IsUniqueEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null; 
        }
        private async Task<bool> IsUniqueUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user == null;
        }
        private async Task<bool> IsCorrectPasswordAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (user == null)
            {
                return false;
            }
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            return result;
        }
    }
}
