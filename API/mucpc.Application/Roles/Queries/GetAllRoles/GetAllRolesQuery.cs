using MediatR;
using mucpc.Application.Roles.Dtos;

namespace mucpc.Application.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
}
