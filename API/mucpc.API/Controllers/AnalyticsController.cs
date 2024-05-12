using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Analytics;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService _analyticsService) : ControllerBase
{
    [HttpGet("academicYears")]
    public async Task<IActionResult> GetAcademicYears()
    {
        try
        {
            var years = await _analyticsService.GetAcademicYears();
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
            var total = await _analyticsService.NumberOfWorkShops();
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
            var total = await _analyticsService.NumberOfInstructors();
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
            var workshop = await _analyticsService.GetHighestRatedWorkshop();
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
            var instructor = await _analyticsService.GetHighestRatedInstructor();
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
            var workshop = await _analyticsService.GetHighestRatedWorkshopInAnAcademicYear(year);
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
            var instructor = await _analyticsService.GetHighestRatedInstructorInAnAcademicYear(year);
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
            var total = await _analyticsService.NumberOfWorkShopsInAnAcademicYear(year);
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
            var total = await _analyticsService.NumberOfStudents();

            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}


