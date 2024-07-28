using FilteringandPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Workshops.Commands.CreateWorkshop;
using mucpc.Application.Workshops.Commands.DeleteWorkshop;
using mucpc.Application.Workshops.Commands.EvaluateWorkshop;
using mucpc.Application.Workshops.Commands.UpdateWorkShop;
using mucpc.Application.Workshops.Dtos;
using mucpc.Application.Workshops.Queries.GetAllWorkshops;
using mucpc.Application.Workshops.Queries.GetByAcademicYear;
using mucpc.Application.Workshops.Queries.GetEvaluationForm;
using mucpc.Application.Workshops.Queries.GetRegisteredEmails;
using mucpc.Application.Workshops.Queries.GetRegisterRequests;
using mucpc.Application.Workshops.Queries.GetRegistrationForm;
using mucpc.Application.Workshops.Queries.GetWorkshopById;
using mucpc.Application.Workshops.Queries.GetWorkShopRating;
using mucpc.Application.Workshops.Queries.GetWorkshopsOfRecentSemester;
using mucpc.Application.Workshops.RegisterRequests.Commands.AddRegisterRequest;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using System.Linq.Expressions;
using System.Text.Json;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkshopsController(IMediator mediator) : Controller
{

    [HttpGet]
    [Route("getall")]
    public async Task<IEnumerable<WorkshopDto>> GetAll()
    {
        return await mediator.Send(new GetAllWorkshopsQuery());
    }

    [HttpGet]
    [Route("workshopsOfRecentSemester")]
    public async Task<IEnumerable<WorkshopDto>> GetWorkshopsOfRecentSemester()
    {
        return await mediator.Send(new GetWorkshopsOfRecentSemesterQuery());

    }


    [HttpGet]
    public async Task<IEnumerable<WorkshopDto>> Get([FromQuery] SearchParams searchParam, HttpResponse response)
    {
        var workshops = await mediator.Send(new GetAllWorkshopsQuery());

        List<ColumnFilter> columnFilters = new List<ColumnFilter>();
        if (!String.IsNullOrEmpty(searchParam.ColumnFilters))
        {
            try
            {
                columnFilters.AddRange(JsonSerializer.Deserialize<List<ColumnFilter>>(searchParam.ColumnFilters));
            }
            catch (Exception)
            {
                columnFilters = new List<ColumnFilter>();
            }
        }

        List<ColumnSorting> columnSorting = new List<ColumnSorting>();
        if (!String.IsNullOrEmpty(searchParam.OrderBy))
        {
            try
            {
                columnSorting.AddRange(JsonSerializer.Deserialize<List<ColumnSorting>>(searchParam.OrderBy));
            }
            catch (Exception)
            {
                columnSorting = new List<ColumnSorting>();
            }
        }

        Expression<Func<WorkshopDto, bool>> filters = null;
        //First, we are checking our SearchTerm. If it contains information we are creating a filter.
        var searchTerm = "";
        if (!string.IsNullOrEmpty(searchParam.SearchTerm))
        {
            searchTerm = searchParam.SearchTerm.Trim().ToLower();
            filters = x => x.Title.ToLower().Contains(searchTerm);
        }
        // Then we are overwriting a filter if columnFilters has data.
        if (columnFilters.Count > 0)
        {
            var customFilter = CustomExpressionFilter<WorkshopDto>.CustomFilter(columnFilters, "WorkshopDto");
            filters = customFilter;
        }


        var query = workshops.AsQueryable().CustomQuery(filters);

        query = CustomExpressionSort<WorkshopDto>.CustomSort(columnSorting, query);

        var count = query.Count();
        var filteredData = query.CustomPagination(searchParam.PageNumber, searchParam.PageSize).ToList();

        var pagedList = new PagedList<WorkshopDto>(filteredData, count, searchParam.PageNumber, searchParam.PageSize);

        if (pagedList != null)
        {
            Response.AddPaginationHeader(pagedList.MetaData);
        }

        return pagedList;
    }

    [HttpGet]
    [Route("getByAcademicYear")]
    public async Task<IEnumerable<WorkshopDto>> GetByAcademicYear([FromQuery] int AcademicYear)
    {

        return await mediator.Send(new GetByAcademicYearQuery(AcademicYear));
    }

    [HttpGet("get")]
    public async Task<ActionResult<WorkshopDto>> Get([FromQuery] long workshopId)
    {
        try
        {
            var workShop = await mediator.Send(new GetWorkshopByIdQuery(workshopId));
            return Ok(workShop);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> Create(CreateWorkshopCommand command)
    {
        try
        {
            if (command.InstructorId == 0)
            {
                command.InstructorId = null;
            }
            await mediator.Send(command);
            return Ok("WorkShop added Successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> Update(UpdateWorkShopCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Ok("WorkShop Updated Successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> Delete([FromQuery] long workshopId)
    {
        try
        {

            await mediator.Send(new DeleteWorkshopCommand(workshopId));
            return Ok("Workshop deleted successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegisteredEmails")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> GetRegisteredEmails([FromQuery] long workshopId)
    {
        try
        {
            var emails = await mediator.Send(new GetRegisteredEmailsQuery(workshopId));
            return Ok(emails);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getWorkshopRating")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<IActionResult> GetWorkShopRating([FromQuery] long workshopId)
    {
        try
        {
            var rating = await mediator.Send(new GetWorkShopRatingQuery(workshopId));
            return Ok(rating);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getEvaluationForm")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> GetEvalutionForm([FromQuery] long workshopId)
    {
        try
        {
            var form = await mediator.Send(new GetEvaluationFormQuery(workshopId));
            return Ok(form);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegistrationForm")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> GetRegistrationForm([FromQuery] long workshopId)
    {
        try
        {
            var form = await mediator.Send(new GetRegistrationFormQuery(workshopId));
            return Ok(form);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> Register(AddRegisterRequestCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("evaluate")]
    [Authorize(Roles = "Manager,Staff,Student")]
    public async Task<IActionResult> Evaluate(EvaluateWorkshopCommand command)
    {
        try
        {
            await mediator.Send(command);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegisterRequests")]
    [Authorize(Roles = "Manager,Staff")]
    public async Task<ActionResult<IEnumerable<RegisterRequestDto>>> GetRegisterRequests([FromQuery] long workshopId)
    {
        try
        {
            var requests = await mediator.Send(new GetRegisterRequestsQuery(workshopId));
            return Ok(requests);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
