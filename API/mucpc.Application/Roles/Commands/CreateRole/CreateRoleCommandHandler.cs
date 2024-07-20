using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler(IUnitOfWork unitOfWork,
    IMapper _mapper) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(request);
        await unitOfWork.Roles.AddRole(role);
    }
}
