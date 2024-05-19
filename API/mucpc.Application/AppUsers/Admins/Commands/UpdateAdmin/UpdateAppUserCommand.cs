using MediatR;
using System.ComponentModel.DataAnnotations;


namespace mucpc.Application.AppUsers.Admins.Commands.UpdateAdmin;

public class UpdateAppUserCommand : IRequest
{
    public long Id { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    public int? RoleId { get; set; }

}
