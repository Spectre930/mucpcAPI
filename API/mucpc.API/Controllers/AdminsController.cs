using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.AppUsers.Admins.Commands.CreateAdmin;
using mucpc.Application.AppUsers.Admins.Commands.DeleteAdmin;
using mucpc.Application.AppUsers.Admins.Commands.UpdateAdmin;
using mucpc.Application.AppUsers.Admins.Queries.GetAdminById;
using mucpc.Application.AppUsers.Admins.Queries.GetAllAdmins;
using mucpc.Application.AppUsers.Dtos;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Manager")]
public class AdminsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    [Route("getall")]
    public async Task<IEnumerable<AppUserDto>> GetAll()
    {

        // var users = await _adminService.GetAllUsers();
        var users = await _mediator.Send(new GetAllAdminsQuery());
        return users;

    }

    [HttpGet("get")]
    public async Task<IActionResult> Get([FromQuery] long adminId)
    {
        try
        {
            var Admin = await _mediator.Send(new GetAdminByIdQuery(adminId));
            return Ok(Admin);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateAppUserCommand dto)
    {
        try
        {
            await _mediator.Send(dto);
            return Ok(new { message = "Admin added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(UpdateAppUserCommand user)
    {
        try
        {
            await _mediator.Send(user);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] long adminId)
    {
        try
        {
            await _mediator.Send(new DeleteAppUserCommand(adminId));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

}
