using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Instructors;
using mucpc.Application.Instructors.Dtos;
using mucpc.Domain.Entities;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController(IInstructorsService _instructorsService) : ControllerBase
{

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllInstructors()
    {
        var instructors = await _instructorsService.GetAll();
        return Ok(instructors);
    }

    [HttpGet("get")]
    public async Task<ActionResult<Instructor>> Get([FromQuery] long instructorId)
    {
        try
        {
            var instructor = await _instructorsService.GetById(instructorId);
            return Ok(instructor);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateInstructorDto dto)
    {
        try
        {

            await _instructorsService.AddInstructor(dto);
            return Ok(new { message = "Instructor added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(InstructorDto instructor)
    {
        try
        {
            await _instructorsService.UpdateInstructor(instructor);
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
            await _instructorsService.DeleteInstructor(instructorId);
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
            var workshops = await _instructorsService.GetWorkShops(instructorId);
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
            var rating = await _instructorsService.GetInstructorRatingInAWorkShop(workShopId);
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
            var rating = await _instructorsService.GetOverAllInstructorRating(instructorId);
            return Ok(rating);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
