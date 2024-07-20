using MediatR;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Instructors;
using mucpc.Application.Instructors.Commands.AddInstructor;
using mucpc.Application.Instructors.Commands.DeleteInstructor;
using mucpc.Application.Instructors.Commands.UpdateInstructor;
using mucpc.Application.Instructors.Dtos;
using mucpc.Application.Instructors.Queries.GetAllInstructors;
using mucpc.Application.Instructors.Queries.GetById;
using mucpc.Application.Instructors.Queries.GetInstructorRatingInAWorkShop;
using mucpc.Application.Instructors.Queries.GetOverAllInstructorRating;
using mucpc.Application.Instructors.Queries.GetWorkShops;
using mucpc.Domain.Entities;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController(IMediator _mediator) : ControllerBase
{

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllInstructors()
    {
        var instructors = await _mediator.Send(new GetAllInstructorsQuery());
        return Ok(instructors);
    }

    [HttpGet("get")]
    public async Task<ActionResult<Instructor>> Get([FromQuery] long instructorId)
    {
        try
        {
            var instructor = await _mediator.Send(new GetByIdQuery(instructorId));
            return Ok(instructor);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(AddInstructorCommand dto)
    {
        try
        {

            await _mediator.Send(dto);
            return Ok(new { message = "Instructor added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(UpdateInstructorCommand instructor)
    {
        try
        {
            await _mediator.Send(instructor);
            return Ok(new { message = "Instructor Updated Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] long instructorId)
    {
        try
        {
            await _mediator.Send(new DeleteInstructorCommand(instructorId));
            return Ok(new { message = "Instructor Deleted Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("getWorkShops")]
    public async Task<IActionResult> GetWorkShops([FromQuery] long instructorId)
    {
        try
        {
            var workshops = await _mediator.Send(new GetWorkShopsQuery(instructorId));
            return Ok(workshops);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });

        }
    }

    [HttpGet]
    [Route("getRatingInaWorkshop")]
    public async Task<IActionResult> GetRatingInAWorkshop([FromQuery] long workShopId)
    {
        try
        {
            var rating = await _mediator.Send(new GetInstructorRatingInAWorkShopQuery(workShopId));
            return Ok(rating);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    [Route("OverAllRating")]
    public async Task<IActionResult> GetOverAllRating([FromQuery] long instructorId)
    {
        try
        {
            var rating = await _mediator.Send(new GetOverAllInstructorRatingQuery(instructorId));
            return Ok(rating);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
