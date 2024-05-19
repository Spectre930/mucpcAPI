using MediatR;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.AppUsers.Admins.Commands.DeleteAdmin;

public class DeleteAppUserCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteAppUserCommand>
{
    public async Task Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.AppUsers.DeleteUser(request.Id);
    }
}
