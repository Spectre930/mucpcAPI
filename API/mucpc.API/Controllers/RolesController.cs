using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Roles.Commands.CreateRole;
using mucpc.Application.Roles.Commands.DeleteRole;
using mucpc.Application.Roles.Commands.UpdateRole;
using mucpc.Application.Roles.Queries.GetAllRoles;
using mucpc.Application.Roles.Queries.GetById;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Manager,Staff")]
public class RolesController(IMediator _mediator) : ControllerBase
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] long roleId)
    {
        try
        {
            var role = await _mediator.Send(new GetByIdQuery(roleId));

            return Ok(role);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRoleCommand dto)
    {
        try
        {
            await _mediator.Send(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoleCommand role)
    {
        try
        {
            await _mediator.Send(role);
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
            await _mediator.Send(new DeleteRoleCommand(roleId));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}
