using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.AppUsers.Commands.ChangePassword;
using mucpc.Application.AppUsers.Commands.ResetPassword;
using mucpc.Application.AppUsers.Queries.Login;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator _mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery command)
    {
        try
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("changePassword")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand comand)
    {
        try
        {
            await _mediator.Send(comand);
            return Ok(new { message = "Password Changed Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("resetPassword")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok(new { message = "Password Reset Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
