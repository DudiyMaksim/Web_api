﻿using Microsoft.AspNetCore.Mvc;
using Web_api.BLL.Dtos.Role;
using Web_api.BLL.Services.Role;
namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRoleDto dto)
        {
            var result = await _roleService.CreateAsync(dto);

            return result.IsSuccess ? Ok("Role created") : BadRequest("Role not created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRoleDto dto)
        {
            var result = await _roleService.UpdateAsync(dto);

            return result.IsSuccess ? Ok("Role updated") : BadRequest("Role not updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is required");
            }

            var result = await _roleService.DeleteAsync(id);

            return result.IsSuccess ? Ok("Role was deleted") : BadRequest("Role was not deleted");
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(string? id)
        {
            if (string.IsNullOrEmpty (id))
            {
                return BadRequest("Id is required");
            }

            var result = await _roleService.GetByIdAsync(id);

            return result != null ? Ok(result) : BadRequest("Role not found");
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _roleService.GetAllAsync();

            return Ok(result);
        }
    }
}
