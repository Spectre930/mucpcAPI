using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.RegisterRequests.Queries.GetAllRegisterRequests;

public class GetAllRegisterRequestsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllRegisterRequestsQuery, List<RegisterRequestDto>>
{
    public async Task<List<RegisterRequestDto>> Handle(GetAllRegisterRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await unitOfWork.RegisterRequests.GetAllAsync();

        return mapper.Map<List<RegisterRequestDto>>(requests);
    }
}
