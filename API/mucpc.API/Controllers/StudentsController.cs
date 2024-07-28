using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Students.Commands.AddStudent;
using mucpc.Application.Students.Commands.DeleteStudent;
using mucpc.Application.Students.Commands.UpdateStudent;
using mucpc.Application.Students.Dtos;
using mucpc.Application.Students.Queries.GetAll;
using mucpc.Application.Students.Queries.GetStudentById;
using mucpc.Application.Students.Queries.GetStudentWorkshops;
using mucpc.Application.Workshops.Dtos;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    [Route("getall")]
    [Authorize(Roles = "Manager,Staff")]

    public async Task<IEnumerable<StudentDto>> GetAll()
    {

        return await mediator.Send(new GetAllStudentsQuery());

    }


    [HttpGet("get")]
    [Authorize(Roles = "Manager,Staff,Student")]

    public async Task<ActionResult<StudentDto>> Get([FromQuery] long studentId)
    {
        try
        {
            var student = await mediator.Send(new GetStudentByIdQuery(studentId));
            return Ok(student);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(AddStudentCommand command)
    {
        try
        {

            await mediator.Send(command);
            return Ok(new { message = "Student added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    [Route("update")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> Update(UpdateStudentCommand student)
    {

        try
        {
            await mediator.Send(student);
            return Ok(new { message = "Student Updated Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


    [HttpDelete]
    [Route("delete")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> Delete([FromQuery] long studentId)
    {
        try
        {
            await mediator.Send(new DeleteStudentCommand(studentId));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    [Route("workShops")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<ActionResult<IEnumerable<WorkshopDto>>> StudentWorkShops([FromQuery] long studentId)
    {
        try
        {
            var workshops = await mediator.Send(new GetStudentWorkshopsQuery(studentId));
            return Ok(workshops);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
