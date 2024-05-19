using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Workshops.RegisterRequests;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterReguestsController(IRegisterRequestsService _RRservice) : ControllerBase
{
    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<RegisterRequestDto>>> GetAll()
    {
        var registerRequests = await _RRservice.GetAll();

        return Ok(registerRequests);
    }

    [HttpGet("get")]
    public async Task<ActionResult<RegisterRequestDto>> Get([FromQuery] long requestId)
    {
        try
        {
            var request = await _RRservice.GetById(requestId);
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
            await _RRservice.VerifyRequest(requestId, isAccepted);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
