using MediatR;
using mucpc.Application.AppUsers.Admins.Commands.CreateAdmin;

namespace mucpc.Application.Students.Commands.AddStudent;

public class AddStudentCommand : IRequest
{
    public CreateAppUserCommand user { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Major { get; set; }
    public string? Faculty { get; set; }
}
