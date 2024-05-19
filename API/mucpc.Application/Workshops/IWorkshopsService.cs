using FilteringandPagination;
using mucpc.Application.Forms.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops;

public interface IWorkshopsService
{
    Task<IEnumerable<WorkshopDto>> GetAll();
    Task<WorkshopDto> GetById(long workshopId);
    Task AddWorkShop(CreateWorkshopDto dto);
    Task EvaluateWorkshop(long workshopId, CreateFormResponseCommand evaluation);
    Task<List<string>> GetRegisteredEmails(long WorkShopId);
    Task<List<RegisterRequestDto>> GetRegisterRequests(long workshopId);
    Task<double?> GetWorkShopRating(long WorkShopId);
    Task<IEnumerable<WorkshopDto>> GetWorkshopsOfAnAcedemicYear(int academicYear);
    Task<IEnumerable<WorkshopDto>> GetWorkshopsOfRecentSemester();
    Task UpdateWorkShop(WorkshopDto workShop);
    Task DeleteWorkshop(long workshopId);
    Task<FormDto> GetEvaluationForm(long workshopId);
    Task<FormDto> GetRegistrationForm(long workshopId);
}