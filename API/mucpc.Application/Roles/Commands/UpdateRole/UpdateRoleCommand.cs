using MediatR;


namespace mucpc.Application.Roles.Commands.UpdateRole;

public class UpdateRoleCommand() : IRequest
{
    public int Id { get; set; }
    public string RoleName { get; set; }
}

