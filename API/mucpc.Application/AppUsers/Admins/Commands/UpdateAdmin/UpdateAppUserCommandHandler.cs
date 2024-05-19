using AutoMapper;
using MediatR;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.AppUsers.Admins.Commands.UpdateAdmin;

public class UpdateAppUserCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateAppUserCommand>
{
    public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
    {

        var admin = await _unitOfWork.AppUsers.GetFirstOrDefaultAsync(x => x.Id == request.Id);

        _mapper.Map(request, admin);

        await _unitOfWork.AppUsers.UpdateUser(admin);
    }
}
