using MediatR;
using mucpc.Application.Forms.FormResponses.Dtos;

namespace mucpc.Application.Forms.FormResponses.Queries.GetResponseById;

public class GetResponseByIdQuery(long id) : IRequest<FormResponseDto>
{
    public long Id { get; set; } = id;
}
