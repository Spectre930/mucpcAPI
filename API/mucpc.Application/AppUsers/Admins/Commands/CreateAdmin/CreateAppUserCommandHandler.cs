using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;


namespace mucpc.Application.AppUsers.Admins.Commands.CreateAdmin;

public class CreateAppUserCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateAppUserCommand>
{
    public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<AppUser>(request);
        await _unitOfWork.AppUsers.AddUser(obj);
    }
}
