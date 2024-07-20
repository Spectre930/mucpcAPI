using Microsoft.EntityFrameworkCore;
using mucpc.Dmain.Repositories;
using mucpc.Domain.Entities;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Repositories;

internal class RoleRepository(mucpcDbContext _db)
    : Repository<Role>(_db),
    IRoleRepository
{
    public async Task AddRole(Role role)
    {
        var obj = await _db.Roles.Where(r => r.RoleName == role.RoleName).FirstOrDefaultAsync();

        if (obj != null)
            throw new Exception("Role Already Exists!");

        _db.Roles.Add(role);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var dbObj = await _db.Roles.FindAsync(id) ?? throw new Exception("Role Not Found!");

        _db.Roles.Remove(dbObj);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateRole(Role role)
    {
        _db.Roles.Update(role);
        await _db.SaveChangesAsync();
    }

}
