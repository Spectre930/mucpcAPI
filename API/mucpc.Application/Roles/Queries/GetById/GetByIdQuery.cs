using MediatR;
using mucpc.Application.Roles.Dtos;

namespace mucpc.Application.Roles.Queries.GetById;

public class GetByIdQuery(long id) : IRequest<RoleDto>
{
    public long Id { get; set; } = id;
}