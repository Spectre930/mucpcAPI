using AutoMapper;
using mucpc.Application.AppUsers.Dtos;
using mucpc.Dmain.DTO;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;


namespace mucpc.Application.AppUsers.Admins;

public class AdminsService(IAppUserRepository _userRepository, IMapper _mapper) : IAdminsService
{
    public async Task<List<AppUserDto>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        users = users.Where(x => x.Role.RoleName != "Student").ToList();
        return _mapper.Map<List<AppUserDto>>(users);
    }

    public async Task<AppUserDto> GetUserById(long id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<AppUserDto>(user);
    }

    public async Task AddUser(CreateAppUserDto user)
    {
        var obj = _mapper.Map<AppUser>(user);
        await _userRepository.AddUser(obj);
    }
    public async Task UpdateUser(AppUserDto user)
    {
        var obj = _mapper.Map<AppUser>(user);
        await _userRepository.UpdateUser(obj);
    }
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
