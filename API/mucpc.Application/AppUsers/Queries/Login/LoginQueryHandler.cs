using MediatR;
using mucpc.Dmain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucpc.Application.AppUsers.Queries.Login;

public class LoginQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<LoginQuery, string>
{
    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var token = await _unitOfWork.AppUsers.Login(request.Email, request.Password);
        return token;
    }
}
