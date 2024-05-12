

using mucpc.Application.Roles.Dtos;
using System.ComponentModel.DataAnnotations;

namespace mucpc.Application.AppUsers.Dtos;

public class AppUserDto
{
    public long Id { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public string Password { get; set; }

    public int RoleId { get; set; }
    public RoleDto Role { get; set; }
}
