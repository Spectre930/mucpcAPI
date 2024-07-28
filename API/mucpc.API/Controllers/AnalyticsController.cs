using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Analytics.Queries.GetAcademicYears;
using mucpc.Application.Analytics.Queries.GetHighestRatedInstructor;
using mucpc.Application.Analytics.Queries.GetHighestRatedInstructorInAnAcademicYear;
using mucpc.Application.Analytics.Queries.GetHighestRatedWorkshop;
using mucpc.Application.Analytics.Queries.GetHighestRatedWorkshopInAnAcademicYear;
using mucpc.Application.Analytics.Queries.NumberOfInstructors;
using mucpc.Application.Analytics.Queries.NumberOfStudents;
using mucpc.Application.Analytics.Queries.NumberOfWorkShops;
using mucpc.Application.Analytics.Queries.NumberOfWorkShopsInAnAcademicYear;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Manager")]
public class AnalyticsController(Mediator _mediator) : ControllerBase
{
    [HttpGet("academicYears")]
    public async Task<IActionResult> GetAcademicYears()
    {
        try
        {
            var years = await _mediator.Send(new GetAcademicYearsQuery());
            return Ok(years);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("totalNumberOfWorkshops")]
    public async Task<IActionResult> GetNumberOfWorkShops()
    {
        try
        {
            var total = await _mediator.Send(new NumberOfWorkShopsQuery());
            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("totalNumberOfInstructors")]
    public async Task<IActionResult> NumberOfInstructors()
    {
        try
        {
            var total = await _mediator.Send(new NumberOfInstructorsQuery());
            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("highestRatedWorkshop")]
    public async Task<IActionResult> GetHighestRatedWorkshop()
    {
        try
        {
            var workshop = await _mediator.Send(new GetHighestRatedWorkshopQuery());
            return Ok(workshop);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("highestRatedInstructor")]
    public async Task<IActionResult> GetHighestRatedInstructor()
    {
        try
        {
            var instructor = await _mediator.Send(new GetHighestRatedInstructorQuery());
            return Ok(instructor);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("highestRatedWorkshopInAnAcademicYear")]
    public async Task<IActionResult> GetHighestRatedWorkshopInAnAcademicYear([FromQuery] int year)
    {
        try
        {
            var workshop = await _mediator.Send(new GetHighestRatedWorkshopInAnAcademicYearQuery(year));
            return Ok(workshop);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("highestRatedInstructorInAnAcademicYear")]
    public async Task<IActionResult> GetHighestRatedInstructorInAnAcademicYear([FromQuery] int year)
    {
        try
        {
            var instructor = await _mediator.Send(new GetHighestRatedInstructorInAnAcademicYearQuery(year));
            return Ok(instructor);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpGet("numberOfWorkShopsInAnAcademicYear")]
    public async Task<IActionResult> NumberOfWorkShopsInAnAcademicYear([FromQuery] int year)
    {
        try
        {
            var total = await _mediator.Send(new NumberOfWorkShopsInAnAcademicYearQuery(year));
            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("totalNumberOfStudents")]
    public async Task<IActionResult> GetTotalNumberOfStudents()
    {
        try
        {
            var total = await _mediator.Send(new NumberOfStudentsQuery());

            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}


