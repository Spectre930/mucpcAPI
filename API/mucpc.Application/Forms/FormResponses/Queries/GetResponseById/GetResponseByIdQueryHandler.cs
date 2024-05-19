using AutoMapper;
using MediatR;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.FormResponses.Queries.GetResponseById;

public class GetResponseByIdQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<GetResponseByIdQuery, FormResponseDto>
{
    public async Task<FormResponseDto> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await unitOfWork.FormResponses.GetResponseById(request.Id);
        return mapper.Map<FormResponseDto>(response);
    }
}
