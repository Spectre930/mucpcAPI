using AutoMapper;
using MediatR;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Forms.Queries.GetFormResponses;

public class GetFormResponsesQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<GetFormResponsesQuery, IEnumerable<FormResponseDto>>
{
    public async Task<IEnumerable<FormResponseDto>> Handle(GetFormResponsesQuery request, CancellationToken cancellationToken)
    {
        var responses = await unitOfWork.Forms.GetFormResponses(id);
        return mapper.Map<IEnumerable<FormResponseDto>>(responses);
    }
}
