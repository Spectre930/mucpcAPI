using mucpc.Application.Workshops.RegisterRequests.Dtos;

namespace mucpc.Application.Workshops.RegisterRequests;

public interface IRegisterRequestsService
{
    Task<IEnumerable<RegisterRequestDto>> GetAll();
    Task<RegisterRequestDto> GetById(long requestId);
    Task AddRegisterRequest(CreateRegisterRequestDto request, long workshopId);
    Task VerifyRequest(long requestId, bool isAccepted);
}
