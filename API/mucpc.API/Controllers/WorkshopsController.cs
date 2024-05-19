using FilteringandPagination;
using Microsoft.AspNetCore.Mvc;
using mucpc.Application.Forms;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Workshops;
using mucpc.Application.Workshops.Dtos;
using mucpc.Application.Workshops.RegisterRequests;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Domain.Entities;
using System.Linq.Expressions;
using System.Text.Json;

namespace mucpc.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkshopsController(IWorkshopsService _workshopsService,
    IFormService _formService,
    IRegisterRequestsService _RRservice) : Controller
{

    [HttpGet]
    [Route("getall")]
    public async Task<IEnumerable<WorkshopDto>> GetAll()
    {
        return await _workshopsService.GetAll();
    }

    [HttpGet]
    [Route("workshopsOfRecentSemester")]
    public async Task<IEnumerable<WorkshopDto>> GetWorkshopsOfRecentSemester()
    {
        var workshops = await _workshopsService.GetWorkshopsOfRecentSemester();
        return workshops;
    }


    [HttpGet]
    public async Task<IEnumerable<WorkshopDto>> Get([FromQuery] SearchParams searchParam, HttpResponse response)
    {
        var workshops = await _workshopsService.GetAll();

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

        var workshops = await _workshopsService.GetAll();
        return workshops.Where(w => w.AcedemicYear == AcademicYear);
    }

    [HttpGet("get")]
    public async Task<ActionResult<WorkshopDto>> Get([FromQuery] long workshopId)
    {
        var workShop = await _workshopsService.GetById(workshopId);
        return Ok(workShop);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateWorkshopDto dto)
    {
        try
        {
            if (dto.InstructorId == 0)
            {
                dto.InstructorId = null;
            }
            await _workshopsService.AddWorkShop(dto);
            return Ok("WorkShop added Successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(WorkshopDto workShop)
    {
        try
        {
            await _workshopsService.UpdateWorkShop(workShop);
            return Ok("WorkShop Updated Successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete([FromQuery] long workshopId)
    {
        try
        {

            await _workshopsService.DeleteWorkshop(workshopId);
            return Ok("Workshop deleted successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegisteredEmails")]
    public async Task<IActionResult> GetRegisteredEmails([FromQuery] long workshopId)
    {
        try
        {
            var emails = await _workshopsService.GetRegisteredEmails(workshopId);
            return Ok(emails);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getWorkshopRating")]
    public async Task<IActionResult> GetWorkShopRating([FromQuery] long workshopId)
    {
        try
        {
            var rating = await _workshopsService.GetWorkShopRating(workshopId);
            return Ok(rating);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getEvaluationForm")]
    public async Task<IActionResult> GetEvalutionForm([FromQuery] long workshopId)
    {
        try
        {
            var form = await _workshopsService.GetEvaluationForm(workshopId);
            var formVm = await _formService.GetById(form.Id);
            return Ok(formVm);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegistrationForm")]
    public async Task<IActionResult> GetRegistrationForm([FromQuery] long workshopId)
    {
        try
        {
            var form = await _workshopsService.GetRegistrationForm(workshopId);
            var formVm = await _formService.GetById(form.Id);
            return Ok(formVm);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(CreateRegisterRequestDto request, [FromQuery] long workshopId)
    {
        try
        {
            await _RRservice.AddRegisterRequest(request, workshopId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("evaluate")]
    public async Task<IActionResult> Evaluate(CreateFormResponseCommand evaluation, [FromQuery] long workshopId)
    {
        try
        {
            await _workshopsService.EvaluateWorkshop(workshopId, evaluation);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("getRegisterRequests")]
    public async Task<ActionResult<IEnumerable<RegisterRequestDto>>> GetRegisterRequests([FromQuery] long workshopId)
    {
        try
        {
            var requests = await _workshopsService.GetRegisterRequests(workshopId);
            return Ok(requests);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
