using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Roles;
using mucpc.Application.Roles.Dtos;
using mucpc.Domain.Entities;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRolesService _rolesService) : ControllerBase
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _rolesService.GetAllRoles();
        return Ok(roles);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] long roleId)
    {
        try
        {
            var role = await _rolesService.GetById(roleId);

            return Ok(role);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRoleDto dto)
    {
        try
        {
            await _rolesService.AddRole(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] RoleDto role)
    {
        try
        {
            await _rolesService.UpdateRole(role);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] long roleId)
    {
        try
        {
            await _rolesService.DeleteRole(roleId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}
