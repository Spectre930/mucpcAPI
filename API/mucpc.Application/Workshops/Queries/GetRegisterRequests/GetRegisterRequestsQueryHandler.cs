using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.Queries.GetRegisterRequests;

public class GetRegisterRequestsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetRegisterRequestsQuery, List<RegisterRequestDto>>
{
    public async Task<List<RegisterRequestDto>> Handle(GetRegisterRequestsQuery request, CancellationToken cancellationToken)
    {
        var registerRequests = await unitOfWork.Workshops.GetRegisterRequests(request.workshopId);

        return mapper.Map<List<RegisterRequestDto>>(registerRequests);
    }

}
