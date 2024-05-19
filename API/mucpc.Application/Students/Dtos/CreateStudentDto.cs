using mucpc.Application.AppUsers.Admins.Commands.CreateAdmin;
using mucpc.Application.AppUsers.Dtos;
using System.ComponentModel.DataAnnotations;

namespace mucpc.Application.Students.Dtos;

public class CreateStudentDto
{
    public CreateAppUserCommand user { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Major { get; set; }
    public string? Faculty { get; set; }
}
