using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.AppUsers.Commands.ResetPassword;

public class ResetPasswordCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<ResetPasswordCommand>
{
    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.AppUsers.ResetPassword(request.Id, request.NewPassword);
    }
}
