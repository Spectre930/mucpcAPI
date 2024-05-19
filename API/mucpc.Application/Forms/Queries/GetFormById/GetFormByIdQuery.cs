
using MediatR;
using mucpc.Application.Forms.Dtos;

namespace mucpc.Application.Forms.Queries.GetFormById;

public class GetFormByIdQuery(long id) : IRequest<FormVm>
{
    public long Id { get; set; } = id;
}
