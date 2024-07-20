using MediatR;

namespace mucpc.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand(long id) : IRequest
{
    public long Id { get; set; } = id;
}
