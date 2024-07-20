using MediatR;

namespace mucpc.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest
{
    public string RoleName { get; set; }
}
