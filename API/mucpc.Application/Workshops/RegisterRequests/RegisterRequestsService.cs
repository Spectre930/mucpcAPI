using AutoMapper;
using mucpc.Application.Forms.FormResponses;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Workshops.RegisterRequests;

internal class RegisterRequestsService(IRegisterRequestRepository _registerRequestRepository,
    IFormResponsesService _FRservice,
    IMapper _mapper) : IRegisterRequestsService
{
    public async Task AddRegisterRequest(CreateRegisterRequestDto request, long workshopId)
    {
        long responseId;
        try
        {
            responseId = await _FRservice.AddResponse(request.FormResponse);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        var registerRequest = _mapper.Map<RegisterRequest>(request);
        registerRequest.FormResponseId = responseId;

        try
        {
            await _registerRequestRepository.AddRegisterRequest(registerRequest);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task<IEnumerable<RegisterRequestDto>> GetAll()
    {
        var requests = await _registerRequestRepository.GetAllAsync(["FormResponse"]);
        return _mapper.Map<IEnumerable<RegisterRequestDto>>(requests);
    }

    public async Task<RegisterRequestDto> GetById(long requestId)
    {
        var request = await _registerRequestRepository.GetFirstOrDefaultAsync(r => r.Id == requestId, ["FormResponse"]) ?? throw new Exception("request not found!");

        return _mapper.Map<RegisterRequestDto>(request);
    }

    public async Task VerifyRequest(long requestId, bool isAccepted)
    {
        await _registerRequestRepository.VerifyRequest(requestId, isAccepted);
    }
}
