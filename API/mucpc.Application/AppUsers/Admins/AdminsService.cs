using AutoMapper;
using mucpc.Dmain.DTO;
using mucpc.Dmain.Repositories;


namespace mucpc.Application.AppUsers.Admins;

public class AdminsService(IAppUserRepository _userRepository, IMapper _mapper) : IAdminsService
{
    public async Task DeleteUser(long id)
    {
        await _userRepository.DeleteUser(id);
    }
    public async Task<string> Login(LoginDto dto)
    {
        return await _userRepository.Login(dto);
    }

    public async Task ChangePassword(string oldPassword, string newPassword, long id)
    {
        await _userRepository.ChangePassword(oldPassword, newPassword, id);
    }
    public async Task ResetPassword(long userId, string newPassword)
    {
        await _userRepository.ResetPassword(userId, newPassword);
    }
}
