using AutoMapper;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops;

internal class WorkshopsService(IWorkshopRepository _workshopRepository,
    IFormRepository _formRepository
    , IMapper _mapper) : IWorkshopsService
{
    public async Task AddWorkShop(CreateWorkshopDto dto)
    {
        var recent = _workshopRepository.GetRecent();

        int currentAcademicYear = recent.academicYear;
        string currentSemester = recent.semester;
        var nextWorkshopNumber = _workshopRepository.GetLastWorkshopNumber(currentAcademicYear, currentSemester[..2]) + 1;

        dto.Number = $"CPC{currentAcademicYear}{currentSemester[..2]}{nextWorkshopNumber}";
        dto.Semester = currentSemester;
        dto.AcedemicYear = currentAcademicYear;

        var workshop = _mapper.Map<WorkShop>(dto);

        await _workshopRepository.AddWorkShop(workshop);
    }

    public async Task UpdateWorkShop(WorkshopDto workShop)
    {
        var workshop = _mapper.Map<WorkShop>(workShop);
        await _workshopRepository.UpdateWorkShop(workshop);
    }

    public async Task<List<string>> GetRegisteredEmails(long WorkShopId)
    {
        return await _workshopRepository.GetRegisteredEmails(WorkShopId);
    }

    public async Task<double?> GetWorkShopRating(long WorkShopId)
    {
        return await _workshopRepository.GetWorkShopRating(WorkShopId);
    }
    public async Task<List<RegisterRequestDto>> GetRegisterRequests(long workshopId)
    {
        var requests = await _workshopRepository.GetRegisterRequests(workshopId);
        return _mapper.Map<List<RegisterRequestDto>>(requests);
    }
    public async Task<IEnumerable<WorkshopDto>> GetWorkshopsOfAnAcedemicYear(int academicYear)
    {
        var workshops = await _workshopRepository.GetWorkshopsOfAnAcedemicYear(academicYear);
        return _mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
    public async Task<IEnumerable<WorkshopDto>> GetWorkshopsOfRecentSemester()
    {
        var workshops = await _workshopRepository.GetWorkshopsOfRecentSemester();
        return _mapper.Map<IEnumerable<WorkshopDto>>(workshops);
    }
    public async Task EvaluateWorkshop(long workshopId, CreateFormResponseCommand evaluation)
    {
        try
        {
            var reposne = _mapper.Map<FormResponse>(evaluation);
            await _workshopRepository.EvaluateWorkshop(workshopId, reposne);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<WorkshopDto>> GetAll()
    {
        var workshops = await _workshopRepository.GetAllAsync(["Instructor"]);
        return _mapper.Map<IEnumerable<WorkshopDto>>(workshops)
            .OrderBy(w => w.AcedemicYear)
            .ThenBy(w => w.Semester); ;
    }

    public async Task<WorkshopDto> GetById(long workshopId)
    {
        var workShop = await _workshopRepository.GetFirstOrDefaultAsync(x => x.Id == workshopId) ?? throw new Exception("workshop not found!");
        return _mapper.Map<WorkshopDto>(workShop);
    }

    public async Task DeleteWorkshop(long workshopId)
    {
        var workShop = await _workshopRepository.GetFirstOrDefaultAsync(x => x.Id == workshopId) ?? throw new Exception("workshop not found!");
        _workshopRepository.Remove(workShop);
    }

    public async Task<FormDto> GetEvaluationForm(long workshopId)
    {
        var form = await _formRepository
            .GetFirstOrDefaultAsync(x => x.WorkShopId == workshopId && x.EvaluationForm) ?? throw new Exception("No Evaluation Form Found!");
        return _mapper.Map<FormDto>(form);
    }

    public async Task<FormDto> GetRegistrationForm(long workshopId)
    {
        var form = await _formRepository
            .GetFirstOrDefaultAsync(x => x.WorkShopId == workshopId && x.RegistrationForm) ?? throw new Exception("No Registration Form Found!");
        return _mapper.Map<FormDto>(form);
    }
}
