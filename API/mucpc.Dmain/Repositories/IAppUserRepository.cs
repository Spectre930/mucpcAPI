using mucpc.Dmain.DTO;
using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IAppUserRepository : IRepository<AppUser>
{
    Task AddUser(AppUser user);
    Task<AppUser> GetById(long id);
    Task DeleteUser(long id);
    Task UpdateUser(AppUser user);
    Task<bool> UserExists(string email);
    Task<string> Login(LoginDto dto);
    Task ChangePassword(string oldPassword, string newPassword, long id);
    Task ResetPassword(long userId, string newPassword);
}
