using AutoMapper;
using MediatR;
using mucpc.Application.Roles.Dtos;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Roles.Queries.GetById;

public class GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetByIdQuery, RoleDto>
{
    public async Task<RoleDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("Role Not Found!");
        return mapper.Map<RoleDto>(role);
    }
}
