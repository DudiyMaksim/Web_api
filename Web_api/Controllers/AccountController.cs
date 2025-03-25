using Microsoft.AspNetCore.Mvc;
using Web_api.BLL.Dtos.Account;
using Web_api.BLL.Services.Account;
using spr311_web_api.DAL.Entities.Identity;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto dto)
        { 
            var user = await _accountService.RegisterAsync(dto);

            if (user == null)
            {
                return BadRequest("Register error");
            }

            return Ok(user);
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            var user = await _accountService.LoginAsync(dto);

            if (user == null)
            {
                return BadRequest("Login error");
            }
            return Ok(user);
        }
    }
}
