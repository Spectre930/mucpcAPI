using AutoMapper;
using Microsoft.Extensions.Logging;
using mucpc.Application.Roles.Dtos;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;

namespace mucpc.Application.Roles;

internal class RolesService(IRoleRepository _roleRepository,
    ILogger<RolesService> _logger,
    IMapper _mapper) : IRolesService
{
    public async Task AddRole(CreateRoleDto dto)
    {
        var role = _mapper.Map<Role>(dto);
        await _roleRepository.AddRole(role);
    }

    public async Task DeleteRole(long id)
    {
        var role = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Role Not Found!");
        _roleRepository.Remove(role);
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles()
    {
        var roles = await _roleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }

    public async Task<RoleDto> GetById(long id)
    {
        var role = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Role Not Found!");
        return _mapper.Map<RoleDto>(role);
    }

    public async Task UpdateRole(RoleDto role)
    {
        var obj = _mapper.Map<Role>(role);
        await _roleRepository.UpdateRole(obj);
    }
}
