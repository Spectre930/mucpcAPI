using System.ComponentModel.DataAnnotations;

namespace mucpc.Domain.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string RoleName { get; set; }
}
