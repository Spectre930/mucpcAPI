using AutoMapper;
using MediatR;
using mucpc.Application.Roles.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{

    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await unitOfWork.Roles.GetAllAsync();
        return mapper.Map<IEnumerable<RoleDto>>(roles);
    }
}

