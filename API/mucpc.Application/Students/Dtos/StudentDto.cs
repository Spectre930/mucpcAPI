using mucpc.Application.AppUsers.Dtos;
using mucpc.Application.Forms.FormResponses.Dtos;
using mucpc.Application.Roles.Dtos;
using mucpc.Application.Workshops.Dtos;
using mucpc.Domain.Entities;


namespace mucpc.Application.Students.Dtos;

public class StudentDto
{
    public long UserId { get; set; }
    public AppUserDto User { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Major { get; set; }
    public string? Faculty { get; set; }
    public ICollection<WorkshopDto>? Workshops { get; set; }
    public ICollection<FormResponseDto>? FormResponses { get; set; }
}
