using MediatR;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Forms.Commands.CreateForm;
using mucpc.Application.Forms.Commands.DeleteForm;
using mucpc.Application.Forms.Commands.UpdateForm;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormQuestions.Commands.AddQuestion;
using mucpc.Application.Forms.FormQuestions.Commands.DeleteQuestion;
using mucpc.Application.Forms.FormQuestions.Commands.EditQuestion;
using mucpc.Application.Forms.FormResponses.Queries.GetResponseById;
using mucpc.Application.Forms.Queries.GetAllForms;
using mucpc.Application.Forms.Queries.GetFormAnalytics;
using mucpc.Application.Forms.Queries.GetFormById;
using mucpc.Application.Forms.Queries.GetFormResponses;
using mucpc.Dmain.DTO.FormAnalytics;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormsController(Mediator _mediator) : ControllerBase
{
    [HttpGet]
    [Route("getall")]
    public async Task<IEnumerable<FormVm>> GetAll()
    {
        var forms = await _mediator.Send(new GetAllFormsQuery());
        return forms;
    }

    [HttpGet("get")]
    public async Task<ActionResult<FormVm>> Get([FromQuery] long formId)
    {
        try
        {
            var form = await _mediator.Send(new GetFormByIdQuery(formId));
            return Ok(form);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateFormCommand dto)
    {
        try
        {
            await _mediator.Send(dto);
            return Ok(new { message = "Form added Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(UpdateFormCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] long formId)
    {
        try
        {
            await _mediator.Send(new DeleteFormCommand(formId));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Route("editQuestion")]
    public async Task<IActionResult> EditQuestion(EditQuestionCommand question)
    {
        try
        {
            await _mediator.Send(question);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Route("deleteQuestion")]
    public async Task<IActionResult> DeleteQuestion([FromQuery] long questionId)
    {
        try
        {
            await _mediator.Send(new DeleteQuestionCommand(questionId));
            return Ok(new { message = "Question deleted Successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Route("addQuestion")]
    public async Task<IActionResult> AddQuestion(AddQuestionCommand dto, [FromQuery] long formId)
    {
        try
        {
            await _mediator.Send(dto);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    [Route("getAnalytics")]
    public async Task<ActionResult<FormAnalytics>> GetFormAnalytics([FromQuery] long formId)
    {
        var analytics = await _mediator.Send(new GetFormAnalyticsQuery(formId));
        return Ok(analytics);
    }

    [HttpGet]
    [Route("getAllResponses")]
    public async Task<IActionResult> GetAllResponses([FromQuery] long formId)
    {
        try
        {
            var responses = await _mediator.Send(new GetFormResponsesQuery(formId));

            return Ok(responses);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    [Route("getResponse")]
    public async Task<IActionResult> GetResponse([FromQuery] long responseId)
    {
        try
        {
            var response = await _mediator.Send(new GetResponseByIdQuery(responseId));
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
