using MediatR;

namespace mucpc.Application.AppUsers.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public long Id { get; set; }
}


