using MediatR;
using mucpc.Application.AppUsers.Admins.Commands.UpdateAdmin;

namespace mucpc.Application.Students.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest
{
    public UpdateAppUserCommand user { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Major { get; set; }
    public string? Faculty { get; set; }
}
