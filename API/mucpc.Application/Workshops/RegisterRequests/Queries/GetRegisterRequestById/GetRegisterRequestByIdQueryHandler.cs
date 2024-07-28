using AutoMapper;
using MediatR;
using mucpc.Application.Workshops.RegisterRequests.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Workshops.RegisterRequests.Queries.GetRegisterRequestById;

public class GetRegisterRequestByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetRegisterRequestByIdQuery, RegisterRequestDto>
{
    public async Task<RegisterRequestDto> Handle(GetRegisterRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var registerRequest = await unitOfWork.RegisterRequests.GetFirstOrDefaultAsync(x => x.Id == request.Id);
        return mapper.Map<RegisterRequestDto>(registerRequest);
    }
}
