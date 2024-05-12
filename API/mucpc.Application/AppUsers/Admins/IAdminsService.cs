using mucpc.Application.AppUsers.Dtos;
using mucpc.Dmain.DTO;

namespace mucpc.Application.AppUsers.Admins
{
    public interface IAdminsService
    {
        Task AddUser(CreateAppUserDto user);
        Task ChangePassword(string oldPassword, string newPassword, long id);
        Task DeleteUser(long id);
        Task<List<AppUserDto>> GetAllUsers();
        Task<AppUserDto> GetUserById(long id);
        Task<string> Login(LoginDto dto);
        Task ResetPassword(long userId, string newPassword);
        Task UpdateUser(AppUserDto user);
    }
}