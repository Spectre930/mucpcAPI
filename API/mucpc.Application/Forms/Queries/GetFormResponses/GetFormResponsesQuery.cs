using MediatR;
using mucpc.Application.Forms.FormResponses.Dtos;

namespace mucpc.Application.Forms.Queries.GetFormResponses;

public class GetFormResponsesQuery(long id) : IRequest<IEnumerable<FormResponseDto>>
{
    public long Id { get; set; } = id;
}
