using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Workshops.RegisterRequests.Commands.VerifyRequest;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Application.Workshops.RegisterRequests.Queries.GetAllRegisterRequests;
using mucpc.Application.Workshops.RegisterRequests.Queries.GetRegisterRequestById;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Manager,Staff")]

public class RegisterReguestsController(IMediator _mediator) : ControllerBase
{
    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<RegisterRequestDto>>> GetAll()
    {
        var registerRequests = await _mediator.Send(new GetAllRegisterRequestsQuery());

        return Ok(registerRequests);
    }

    [HttpGet("get")]
    public async Task<ActionResult<RegisterRequestDto>> Get([FromQuery] long requestId)
    {
        try
        {
            var query = new GetRegisterRequestByIdQuery(requestId);
            var request = await _mediator.Send(query);
            return Ok(request);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("verify")]
    public async Task<ActionResult> VerifyRequest([FromQuery] long requestId, bool isAccepted)
    {
        try
        {
            var command = new VerifyRequestCommand(requestId, isAccepted);

            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
