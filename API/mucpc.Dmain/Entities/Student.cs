using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mucpc.Domain.Entities;

public class Student

{
    [Key]
    [ForeignKey("User")]
    public long UserId { get; set; }
    public AppUser User { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Major { get; set; }
    public string? Faculty { get; set; }
    public ICollection<WorkShop>? Workshops { get; set; }
    public ICollection<FormResponse>? FormResponses { get; set; }
}
