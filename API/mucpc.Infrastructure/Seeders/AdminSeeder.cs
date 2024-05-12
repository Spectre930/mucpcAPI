

using mucpc.Domain.Entities;
using mucpc.Infrastructure.Seeders.interfaces;
using MUCPC.Infrastructure.Persistence;

namespace mucpc.Infrastructure.Seeders;

internal class AdminSeeder(mucpcDbContext context) : IAdminSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.AppUsers.Any())
            {
                var admin = GetAdmin();
                context.AppUsers.Add(admin);
                await context.SaveChangesAsync();
            }
        }

    }

    private AppUser GetAdmin()
    {
        return new AppUser
        {
            Email = "manager@email.com",
            Password = "$2a$13$kBlfLEjqoSw81MEMRs1i.eiGH9QYbdZTWQZz/JXqTnn6PWCy9tWxO", // Manager1$
            RoleId = context.Roles.FirstOrDefault(r => r.RoleName == "Manager").Id
        };
    }
}


