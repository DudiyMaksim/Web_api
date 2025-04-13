using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Services.Account;
using Web_api.BLL.Services.Jwt;
using Web_api.BLL.Validators.Account;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly RegisterValidator _registerValidator;
        private readonly LoginValidator _loginValidator;
        private readonly IJwtService _jwtService;
        public AccountController(IAccountService accountService, RegisterValidator registerValidator, LoginValidator loginValidator, IJwtService jwtService)
        {
            _accountService = accountService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto dto)
        { 
            var validResult = await _registerValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var user = await _accountService.RegisterAsync(dto);

            if (user == null)
            {
                return BadRequest("Register error");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            var validResult = await _loginValidator.ValidateAsync(dto);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var user = await _accountService.LoginAsync(dto);

            if (user == null)
            {
                return BadRequest("Login error");
            }
            return Ok(user);
        }
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string? userId, string? token)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            if (token == null)
            {
                return BadRequest();
            }
            var result = await _jwtService.ConfirmEmailAsync(userId, token);

            if (result.Succeeded)
                return Ok("Email успішно підтверджено!");

            return BadRequest(result.Errors);
        }
    }
}
