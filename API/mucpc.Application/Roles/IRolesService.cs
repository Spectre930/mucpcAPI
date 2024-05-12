using mucpc.Application.Roles.Dtos;


namespace mucpc.Application.Roles;

public interface IRolesService
{
    Task<IEnumerable<RoleDto>> GetAllRoles();
    Task<RoleDto> GetById(long id);
    Task AddRole(CreateRoleDto dto);
    Task UpdateRole(RoleDto role);
    Task DeleteRole(long id);

}