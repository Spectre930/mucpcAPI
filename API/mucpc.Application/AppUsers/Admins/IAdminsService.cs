using mucpc.Application.AppUsers.Dtos;
using mucpc.Dmain.DTO;

namespace mucpc.Application.AppUsers.Admins
{
    public interface IAdminsService
    {
        Task ChangePassword(string oldPassword, string newPassword, long id);
        Task DeleteUser(long id);
        Task<string> Login(LoginDto dto);
        Task ResetPassword(long userId, string newPassword);
    }
}