using MediatR;
using mucpc.Dmain.Repositories;

namespace mucpc.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoleCommand>
{
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.Roles.Delete(request.Id);
    }
}
