using mucpc.Application.Workshops.Dtos;
using System.ComponentModel.DataAnnotations;

namespace mucpc.Application.Instructors.Dtos;

public class InstructorDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    public string Address { get; set; }
    public int YearsOfExpertise { get; set; }
    public string Major { get; set; }
    public string DegreeLevel { get; set; }
    public double? Rating { get; set; } 
       
    public ICollection<WorkshopDto>? WorkShops { get; set; }
}
