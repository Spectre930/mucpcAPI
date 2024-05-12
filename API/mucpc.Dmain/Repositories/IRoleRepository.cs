using mucpc.Dmain.DTO;
using mucpc.Domain.Entities;

namespace mucpc.Dmain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task AddRole(Role role);
    Task UpdateRole(Role role);
    Task Delete(long id);
}
