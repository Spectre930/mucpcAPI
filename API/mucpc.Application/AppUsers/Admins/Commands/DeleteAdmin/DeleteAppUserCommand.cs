

using MediatR;

namespace mucpc.Application.AppUsers.Admins.Commands.DeleteAdmin;

public class DeleteAppUserCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
