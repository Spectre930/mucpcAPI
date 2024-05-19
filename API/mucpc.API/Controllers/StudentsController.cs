using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Students;
using mucpc.Application.Students.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Domain.Entities;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IStudnetsService _studentsService) : ControllerBase
{

    [HttpGet]
    [Route("getall")]
    public async Task<IEnumerable<StudentDto>> GetAll()
    {

        return await _studentsService.GetAll();

    }


    [HttpGet("get")]
    public async Task<ActionResult<StudentDto>> Get([FromQuery] long studentId)
    {
        try
        {
            var student = await _studentsService.GetById(studentId);
            return Ok(student);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateStudentDto dto)
    {
        try
        {

            await _studentsService.AddStudent(dto);
            return Ok(new { message = "Student added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(StudentDto student)
    {

        try
        {
            await _studentsService.UpdateStudent(student);
            return Ok(new { message = "Student Updated Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] long studentId)
    {
        try
        {
            await _studentsService.DeleteStudent(studentId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    [Route("workShops")]
    public async Task<ActionResult<IEnumerable<WorkshopDto>>> StudentWorkShops([FromQuery] long studentId)
    {
        try
        {
            var workshops = await _studentsService.GetWorkshops(studentId);
            return Ok(workshops);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
