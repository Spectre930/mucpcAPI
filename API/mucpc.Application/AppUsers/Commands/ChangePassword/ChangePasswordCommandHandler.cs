using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.AppUsers.Commands.ChangePassword;

public class ChangePasswordCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.AppUsers.ChangePassword(request.OldPassword, request.NewPassword, request.Id);
    }
}
