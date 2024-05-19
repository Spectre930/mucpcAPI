using MediatR;

namespace mucpc.Application.AppUsers.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest
{
    public long Id { get; set; }
    public string NewPassword { get; set; }
}
