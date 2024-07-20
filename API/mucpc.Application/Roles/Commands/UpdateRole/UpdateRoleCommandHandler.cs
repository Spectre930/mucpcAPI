using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Roles.Commands.UpdateRole;


public class UpdateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateRoleCommand>
{
    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetFirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new Exception("Role Not Found!");
        mapper.Map(request, role);
        await unitOfWork.Roles.UpdateRole(role);
    }
}
