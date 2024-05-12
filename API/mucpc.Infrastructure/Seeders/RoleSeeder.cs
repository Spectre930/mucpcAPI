using mucpc.Domain.Entities;
using mucpc.Infrastructure.Seeders.interfaces;
using MUCPC.Infrastructure.Persistence;


namespace mucpc.Infrastructure.Seeders;

internal class RoleSeeder(mucpcDbContext context) : IRoleSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Roles.Any())
            {
                var roles = GetRoles();
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }

    }

    private List<Role> GetRoles()
    {
        return new List<Role>
        {
            new Role
            {
                RoleName = "Manager"
            },
            new Role
            {
                RoleName = "Staff"
            },
            new Role
            {
                RoleName = "Student"
            }
        };
    }
}

